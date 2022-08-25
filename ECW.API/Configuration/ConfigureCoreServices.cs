using ECW.ApplicationCore.Interfaces;
using ECW.ApplicationCore.Services;
using ECW.Infrastructure.Data;
using ECW.Infrastructure.Data.Queries;
using ECW.Infrastructure.Identity;

namespace ECW.API.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IBasketService, BasketService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IBasketQueryService, BasketQueryService>();

        return services;
    }
}