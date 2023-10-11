using Microsoft.Extensions.DependencyInjection;
using OrderTest.Domain.Services;
using OrderTest.Domain.Services.Implementations;

namespace OrderTest.Domain;

public static class Extensions
{
    public static void AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
    }
}
