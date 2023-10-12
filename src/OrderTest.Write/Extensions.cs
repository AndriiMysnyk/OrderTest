using Microsoft.Extensions.DependencyInjection;

using OrderTest.Write.Services;
using OrderTest.Write.Services.Implementation;

namespace OrderTest.Write;

public static class Extensions
{
    public static void AddWrite(this IServiceCollection services)
    {
        services.AddScoped<IOrderWriteService, OrderWriteService>();
    }
}