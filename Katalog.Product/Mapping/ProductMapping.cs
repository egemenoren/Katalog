using AutoMapper;
using Katalog.Product.Entities;

namespace Katalog.Product.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Category, Entities.Product>().ReverseMap();
            CreateMap<Brand, Entities.Product>().ReverseMap();
            CreateMap<DTOs.ProductDTO, Entities.Product>().ReverseMap();
        }
    }
}
