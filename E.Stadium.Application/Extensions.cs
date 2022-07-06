using E.Stadium.Shared.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace E.Stadium.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();

        //services.Scan(s => s.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
        //    .AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
        //    .AsImplementedInterfaces()
        //    .WithSingletonLifetime());
        return services;
    }
}
