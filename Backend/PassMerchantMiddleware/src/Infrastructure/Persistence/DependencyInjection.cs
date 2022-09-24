using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassMerchantMiddleware.Application.Common.Interfaces;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {

      
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString
                ,
                 b =>
                 {
                     b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
                     b.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                 }
                ));
        
       
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        return services;
       
    
    }
}