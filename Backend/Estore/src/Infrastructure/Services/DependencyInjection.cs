using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PassMerchantMiddleware.Application.Common.Interfaces;
using Services.Services;

namespace Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IDomainEventService, DomainEventService>();
        services.AddTransient<IDateTime, DateTimeService>();
      
        return services;
    }
}