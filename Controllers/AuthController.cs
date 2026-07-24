using Microsoft.AspNetCore.Mvc;
using ProductInventoryAPI.Authentication;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.DTOs.Auth;

namespace ProductInventoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;
        private readonly AppDbContext _context;

        public AuthController(TokenService tokenService, AppDbContext context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = new User
            {
                Id = 1,
                Username = dto.Username,
                Password = dto.Password,
                Role = "Admin"
            };

            var accessToken = _tokenService.CreateToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken();

            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                ExpiryDate = DateTime.Now.AddDays(7),
                UserId = user.Id
            };

            try
            {
                _context.RefreshTokens.Add(refreshTokenEntity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("========== MAIN EXCEPTION ==========");
                Console.WriteLine(ex.ToString());

                if (ex.InnerException != null)
                {
                    Console.WriteLine("========== INNER EXCEPTION ==========");
                    Console.WriteLine(ex.InnerException.ToString());
                }

                throw;
            }

            return Ok(new
            {
                accessToken,
                refreshToken
            });
        }
    }
}