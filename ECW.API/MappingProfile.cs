using AutoMapper;
using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;

namespace ECW.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UpdateBrandRequest, Brand>();
    }
}