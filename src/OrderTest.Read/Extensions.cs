using Microsoft.Extensions.DependencyInjection;

using OrderTest.Read.Services;
using OrderTest.Read.Services.Implementation;
using OrderTest.Read.Translators;
using OrderTest.Read.Translators.Implementation;

namespace OrderTest.Persistance;

public static class Extensions
{
    public static void AddRead(this IServiceCollection services)
    {
        services.AddScoped<IOrderReadService, OrderReadService>();
        services.AddScoped<IOrderTranslator, OrderTranslator>();
    }
}
