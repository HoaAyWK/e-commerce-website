using AutoMapper;
using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.DTOs.Product;
using ECW.ApplicationCore.Entities;

namespace ECW.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Brand, BrandDto>();
        CreateMap<Brand, CreateBrandResponse>();

        CreateMap<Product, ProductDto>();
        CreateMap<Product, CreateProductResponse>();
    }
}