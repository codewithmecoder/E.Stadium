using E.Stadium.Shared.Options;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace E.Stadium.Abstraction.DataProtector;

public static class Extenstions
{
    private const string SectionName = "DataProtector";

    public static IServiceCollection AddDataProtector(this IServiceCollection services)
    {
        DataProtectorOptions options = services.GetOptions<DataProtectorOptions>("DataProtector");
        string text = options.PersistKeyPath;
        if (text.Equals(string.Empty))
        {
            text = AppDomain.CurrentDomain.BaseDirectory;
        }

        services.AddSingleton(options);
        services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(text));
        IDataProtectionProvider service = ServiceProviderServiceExtensions.GetService<IDataProtectionProvider>(services.BuildServiceProvider())!;
        IDataProtector implementationInstance = service.CreateProtector(options.ProtectorKey);
        services.AddSingleton(implementationInstance);
        return services;
    }
}
