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
                       .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                       .ForMember(dest => dest.SubcategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                       .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.SubCategory.CategoryId))
                       .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategory.SubCategoryId));

                config.CreateMap<Category, CategoryDto>()
                        .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                        .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name));

                config.CreateMap<SubCategory, SubCategoryDto>()
                        .ForMember(dest => dest.SubCategoryId, opt => opt.MapFrom(src => src.SubCategoryId))
                        .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Name));
            });
        }
    }
}
