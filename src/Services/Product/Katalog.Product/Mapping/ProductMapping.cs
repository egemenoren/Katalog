using AutoMapper;
using Katalog.Product.DTOs;
using Katalog.Product.Entities;

namespace Katalog.Product.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Category, ProductDTO>().ReverseMap();
            CreateMap<Brand, ProductDTO>().ReverseMap();
            CreateMap<DTOs.ProductDTO, Entities.Product>().ReverseMap();
        }
    }
}
