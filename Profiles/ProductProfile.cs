using AutoMapper;
using ProductInventoryAPI.DTOs;
using ProductInventoryAPI.Models;

namespace ProductInventoryAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            CreateMap<Product, UpdateProductDto>().ReverseMap();
        }
    }
}