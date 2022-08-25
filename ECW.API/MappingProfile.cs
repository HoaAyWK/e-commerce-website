using AutoMapper;
using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.DTOs.Order;
using ECW.ApplicationCore.DTOs.Product;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Entities.OrderAggregate;

namespace ECW.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<Brand, CreateBrandResponse>();

        CreateMap<Product, ProductDto>();
        CreateMap<Product, CreateProductResponse>();

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(
                dest => dest.ProductId,
                opt => opt.MapFrom(src => src.ItemOrdered!.ProductId)
            )
            .ForMember(
                dest => dest.ProductName,
                opt => opt.MapFrom(src => src.ItemOrdered!.ProductName)
            )
            .ForMember(
                dest => dest.Image,
                opt => opt.MapFrom(src => src.ItemOrdered!.ProductImage)
            );

        CreateMap<OrderItemDto, OrderItem>()
            .ForMember(
                dest => dest.ItemOrdered,
                opt => opt.MapFrom(src => new ItemOrdered(src.ProductId, src.ProductName, src.Image))
            );

        CreateMap<Order, OrderDto>()
            .ForMember(
                dest => dest.OrderNumber,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.ShippingAddress,
                opt => opt.MapFrom(src => src.ShipToAddress)
            )
            .ForMember(
                dest => dest.Total,
                opt => opt.MapFrom(src => src.Total())
            )
            .ForMember(
                dest => dest.OrderItems,
                opt => opt.MapFrom(src => src.OrderItems)
            );

        CreateMap<Product, ProductDto>();
    }
}