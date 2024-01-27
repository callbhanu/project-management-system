using AutoMapper;
using ProductAPI.Dto;
using ProductAPI.Models;

namespace ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            return new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductDetailsDto>()
                       .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode))
                       .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Name))
                       .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                       .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                       .ForMember(dest => dest.ProductDescription, opt => opt.MapFrom(src => src.Description))
                       .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                       .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId));


                config.CreateMap<ProductCreateDto, Product>()
                        .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                        .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode))
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                        .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                        .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                        .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                        .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));


            });
        }
    }
}
