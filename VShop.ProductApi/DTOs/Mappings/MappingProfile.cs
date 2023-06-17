using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap(); // reverse map para nao ter que criar outro create map
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
