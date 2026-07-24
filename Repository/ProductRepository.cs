using Microsoft.EntityFrameworkCore;
using ProductInventoryAPI.Data;
using ProductInventoryAPI.Models;

namespace ProductInventoryAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                _context.Products.Add(product);

                await _context.SaveChangesAsync();

                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine("========== DATABASE ERROR ==========");
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("========== INNER EXCEPTION ==========");
                    Console.WriteLine(ex.InnerException.Message);
                }

                throw;
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                _context.Products.Update(product);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("========== DATABASE ERROR ==========");
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("========== INNER EXCEPTION ==========");
                    Console.WriteLine(ex.InnerException.Message);
                }

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                try
                {
                    _context.Products.Remove(product);

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("========== DATABASE ERROR ==========");
                    Console.WriteLine(ex.Message);

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("========== INNER EXCEPTION ==========");
                        Console.WriteLine(ex.InnerException.Message);
                    }

                    throw;
                }
            }
        }
    }
}