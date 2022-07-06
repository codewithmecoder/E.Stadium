using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Vonage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E.Stadium.Shared.Options;

public static class Extensions
{
    public static TOptions GetOptions<TOptions>(this IConfiguration config, string sectionName)
        where TOptions : new()
    {
        var options = new TOptions();

        config.GetSection(sectionName).Bind(options);

        return options;
    }

    public static IServiceCollection AddJwt(this IServiceCollection services)
    {
        JwtOptions options = services!.GetOptions<JwtOptions>("jwt");
        services.AddSingleton(options);
        return services;
    }

    public static string Underscore(this string value)
    {
        return string.Concat(value.Select((char x, int i) => (i > 0 && char.IsUpper(x)) ? ("_" + x) : x.ToString()));
    }

    public static TModel GetOptions<TModel>(this IServiceCollection services, string section) where TModel : new()
    {
        using ServiceProvider provider = services.BuildServiceProvider();
        IConfiguration requiredService = provider.GetRequiredService<IConfiguration>();
        return requiredService.GetOptions<TModel>(section);
    }

    public static string? Right(this string str, int count)
    {
        if (str.Length < count)
        {
            return null;
        }

        return str.Substring(str.Length - count, count);
    }

    public static string? Left(this string str, int count)
    {
        if (str.Length < count)
        {
            return null;
        }

        return str.Substring(0, count);
    }

    public static IServiceCollection AddVonage(this IServiceCollection services)
    {
        VonageOptions options = services.GetOptions<VonageOptions>("Vonage");
        services.AddSingleton(options);
        services.AddTransient<IVonage, VonageRepository>();
        return services;
    }
}
