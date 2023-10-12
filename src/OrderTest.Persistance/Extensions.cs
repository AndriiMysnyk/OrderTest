using Microsoft.Extensions.DependencyInjection;

using OrderTest.Read.Repositories;
using OrderTest.Write.Repositories;
using OrderTest.Persistance.Implementation;

namespace OrderTest.Persistance;

public static class Extensions
{
    public static void AddPersistance(this IServiceCollection services)
    {
        services.AddScoped<IOrdersReadRepository, OrdersRepository>();
        services.AddScoped<IOrdersWriteRepository, OrdersRepository>();
    }
}
