using AutoMapper;

namespace Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
        }   
    }
}