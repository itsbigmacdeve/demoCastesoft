using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Esto se lee de la brand de ProductDto , se le mapea el brand de la entidad Products
            CreateMap<Core.Entities.Products, Dtos.ProductsDto>().ForMember
            (d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(o => o.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}