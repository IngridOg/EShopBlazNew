using AutoMapper;
using EShopBlazNew.Server.Entities;
using EShopBlazNew.Shared.Models;

namespace EShopBlazNew.Server.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductVariantModel, ProductVariant>()
            .ForMember(dest => dest.Color, act => act.MapFrom(src => (byte)src.Color));

        CreateMap<ProductVariantModel, ProductVariant>()
            .ForMember(dest => dest.Color, act => act.MapFrom(src => (byte)src.Color));

        CreateMap<ProductVariant, ProductVariantModel>()
            .ForMember(dest => dest.Color, act => act.MapFrom(src => (ProductColor)src.Color));




        CreateMap<CreateProductModel, Product>()
            .ForMember(dest => dest.Category, act => act.MapFrom(src => (byte)src.Category))
            .ForMember(dest => dest.Season, act => act.MapFrom(src => (byte)src.Season));

        CreateMap<ProductModel, Product>()

            .ForMember(dest => dest.Category, act => act.MapFrom(src => (byte)src.Category))
            .ForMember(dest => dest.Season, act => act.MapFrom(src => (byte)src.Season));

        CreateMap<Product, ProductModel>()

            .ForMember(dest => dest.Category, act => act.MapFrom(src => (ProductCategory)src.Category))
            .ForMember(dest => dest.Season, act => act.MapFrom(src => (SellingSeason)src.Season));
    }
}

