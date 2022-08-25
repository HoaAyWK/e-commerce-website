using System.Reflection;
using ECW.ApplicationCore.Features.Orders;
using MediatR;

namespace ECW.API.Configuration;

public static class ConfigureApiServices
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(CreateOrderCommand).Assembly);
        services.AddAutoMapper(typeof(MappingProfile).Assembly);
        
        return services;
    }
}