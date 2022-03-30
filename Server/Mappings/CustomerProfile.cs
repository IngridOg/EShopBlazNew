using AutoMapper;
using EShopBlazNew.Server.Entities;
using EShopBlazNew.Shared.Models;

namespace EShopBlazNew.Server.Mappings;
public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CreateCustomerModel, Customer>();


        CreateMap<InvoiceLineModel, InvoiceLine>();
        CreateMap<InvoiceModel, Invoice>()
            .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => (DateTime?)src.OrderDate))
            .ForMember(dest => dest.ShippingType, act => act.MapFrom(src => (byte)src.ShippingType))
            .ForMember(dest => dest.PaymentType, act => act.MapFrom(src => (byte)src.PaymentType));
        CreateMap<DetailModel, Detail>();
        CreateMap<ShoppingCartModel, ShoppingCart>();
        CreateMap<CustomerModel, Customer>();


        CreateMap<InvoiceLine, InvoiceLineModel>();
        CreateMap<Invoice, InvoiceModel>()
            .ForMember(dest => dest.OrderDate, act => act.MapFrom(src => (DateTime)src.OrderDate))
            .ForMember(dest => dest.ShippingType, act => act.MapFrom(src => (TypeOfShipping)src.ShippingType))
            .ForMember(dest => dest.PaymentType, act => act.MapFrom(src => (TypeOfPayment)src.PaymentType));
        CreateMap<Detail, DetailModel>();
        CreateMap<ShoppingCart, ShoppingCartModel>();
        CreateMap<Customer, CustomerModel>();
    }
}
