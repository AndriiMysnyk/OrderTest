
using Microsoft.Extensions.DependencyInjection;

using OrderTest.Persistance.Implementation;
using OrderTest.Read.Repositories;

namespace OrderTest.Persistance;

public static class Extensions
{
    public static void AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IOrdersReadRepository, OrdersRepository>();
    }
}
