using ECW.Infrastructure.Data;
using ECW.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECW.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<ProductContext>(c =>
            c.UseSqlServer(configuration.GetConnectionString("ProductConnection")));

        // Add Identity DbContext
        services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"))); 
    }
}