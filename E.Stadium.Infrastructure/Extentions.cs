using E.Stadium.Abstraction.Commands;
using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Queries;
using E.Stadium.Abstraction.Utilities;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Services;
using E.Stadium.Infrastructure.Services.Interfaces;
using E.Stadium.Shared.Commands;
using E.Stadium.Shared.Options;
using E.Stadium.Shared.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mip.Farm.Infrastructure.Repositories;

namespace E.Stadium.Infrastructure;

public static class Extentions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        services.AddTransient<ITokenProvider<UserEntity>, TokenProvider<UserEntity>>();
        services.AddJwt();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IPhoneParser, PhoneParser>();

        services.AddQueries();

        services.AddTransient<IUserRepository, UserRepository>();

        services.AddVonage();
        var options = configuration.GetOptions<PostgresOptions>("Postgres");
        services.AddDbContext<PostgresDbContext>(opt =>
            opt.UseNpgsql(options.ConnectionString));
        //services.AddPostgres<>();
        services.AddPostgresRepositories();

        //services.AddRepositories();

        //services.AddSwagger("Mip.Farm.Api.xml", "My IProfile Farm")
        //    .AddSwaggerExample();
        //services.AddDataProtector();


        //.AddMessageConsumer(new FirstScheduleConsumer());


        //services.AddLocalize("Mip.Lib.Localization.Resources.lang");
        //services.AddLocalization();
        //services.Configure<ForwardedHeadersOptions>(options =>
        //{
        //    options.ForwardedHeaders = ForwardedHeaders.All;
        //});
        return services;
    }

    //public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    //{
    //    var supportedCultures = new[]
    //    {
    //        new CultureInfo("en-US"),
    //        new CultureInfo("fr"),
    //        new CultureInfo("km"),
    //    };

    //    app.UseForwardedHeaders();

    //    app.UseErrorHandler()
    //        .UseMiddleware<AuthorizationRequestHandlerMiddleware>()
    //        .UseMiddleware<LogMiddleware>()
    //        .UseInitializer()
    //        .UseRequestLocalization(new RequestLocalizationOptions
    //        {
    //            DefaultRequestCulture = new RequestCulture("en-US"),
    //            // Formatting numbers, dates, etc.
    //            SupportedCultures = supportedCultures,
    //            // UI strings that we have localized.
    //            SupportedUICultures = supportedCultures
    //        })
    //        .UseAllForwardedHeaders()
    //        .UseLogUserIdMiddleware();


    //    app.UseMasstransit()
    //        .SubscribeConsumer<StartupSchedule>()
    //        .SubscribeConsumer<RecordSchedule>();

    //    return app;
    //}

    //public static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
    //    => builder.UseForwardedHeaders(new ForwardedHeadersOptions
    //    {
    //        ForwardedHeaders = ForwardedHeaders.All
    //    });

    //public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
    //    => builder.UseMiddleware<ErrorHandlerMiddleware>();

    //public static IApplicationBuilder UseInitializer(this IApplicationBuilder builder)
    //{
    //    Task.Run(async () =>
    //    {
    //        using var scope = builder.ApplicationServices.CreateScope();
    //        var sp = scope.ServiceProvider;

    //        await sp.GetRequiredService<IScheduleInitializer>().InitializeAsync();
    //    });
    //    //using var scope = builder.ApplicationServices.CreateScope();
    //    //var sp = scope.ServiceProvider;

    //    return builder;
    //}

    //public static IApplicationBuilder UseLogUserIdMiddleware(this IApplicationBuilder builder)
    //    => builder.UseMiddleware<LogUserIdMiddleware>();
}
