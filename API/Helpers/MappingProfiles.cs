using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Mapeo de Products a ProductsDto
            CreateMap<Core.Entities.Products, Core.CoreDtos.ProductsDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));

            //Mapeo de ProductsDto a Products
            CreateMap<Core.CoreDtos.ProductsDto, Core.Entities.Products>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.ProductCategoryId,opt => opt.Ignore())//Aqui tengo que buscar el id en base al nombre de la categoria
                .ForMember(dest => dest.ProductBrandId, opt => opt.Ignore())// Aqui tengo que buscar el id en base al nombre de la marca
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.PictureUrl));

            // Mapeo de PhotoDto a Photo
            CreateMap<Core.CoreDtos.PhotoDto, Core.Entities.Photo>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.IsMain));

            
            // Mapeo de CreateProductDto a Products (Falta analizar esto)
            CreateMap<Core.CoreDtos.CreateProductDto, Core.Entities.Products>()
                .ForMember(dest => dest.ProductCategoryId, opt => opt.MapFrom(src => src.ProductCategoryId))
                .ForMember(dest => dest.ProductBrandId, opt => opt.MapFrom(src => src.ProductBrandId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Discount, opt => opt.MapFrom(src => src.Discount))
                .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos));
            
            // Mapeo de CreateProductPhotoDto a Photo (Falta analizar esto)
            CreateMap<Core.CoreDtos.CreateProductPhotoDto, Core.Entities.Photo>()
                .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                .ForMember(dest => dest.IsMain, opt => opt.MapFrom(src => src.IsMain));
        }
    }
}
