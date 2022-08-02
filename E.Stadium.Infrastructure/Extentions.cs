using E.Stadium.Abstraction.DataProtector;
using E.Stadium.Abstraction.Jwt;
using E.Stadium.Abstraction.Swagger;
using E.Stadium.Abstraction.Utilities;
using E.Stadium.Application.Middlewares;
using E.Stadium.Core.Entities.Users;
using E.Stadium.Core.Exceptions.Middlewares;
using E.Stadium.Core.Repositories;
using E.Stadium.Infrastructure.Postgres;
using E.Stadium.Infrastructure.Repositories;
using E.Stadium.Infrastructure.Services;
using E.Stadium.Infrastructure.Services.Interfaces;
using E.Stadium.Infrastructure.Swagger.RequestExamples;
using E.Stadium.Shared.Options;
using E.Stadium.Shared.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mip.Farm.Infrastructure.Repositories;
using System.Globalization;

namespace E.Stadium.Infrastructure;

public static class Extentions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddTransient<IPasswordHasher<UserEntity>, PasswordHasher<UserEntity>>();
        services.AddTransient<ITokenProvider<UserEntity>, TokenProvider<UserEntity>>();
        services.AddJwt();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IPhoneParser, PhoneParser>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IStadiumRepository, StadiumRepository>();
        services.AddTransient<IFileUploadStadiumRepository, FileUploadStadiumRepository>();
        services.AddTransient<IFieldRepository, FieldRepository>();
        services.AddTransient<IFileUploadFieldRepository, FileUploadFieldRepository>();
        services.AddVonage();
        var options = builder.Configuration.GetOptions<PostgresOptions>("Postgres");
        //CONNECTIONSTRINGS__DEFAULT=User ID=${POSTGRES_USER};Password=${POSTGRES_PASSWORD};Host=db;Port=5432;Database=${POSTGRES_DB}
        //"Server=192.168.1.112;Port=5432;Database=UntStockCount;User Id=postgres;Password=unt@3456;"
        
        var env = builder.Environment;
        if (env.IsProduction())
        {
            var dbServer = builder.Configuration["POSTGRESSERVER"];
            var dbPassword = builder.Configuration["POSTGRES_PASSWORD"];
            var dbName = builder.Configuration["POSTGRES_DB"];
            var dbUser = builder.Configuration["POSTGRES_USER"];
            string dbUrl;
            if (dbPassword is null || dbServer is null || dbName is null || dbUser is null) dbUrl = null!;
            else dbUrl = $"Server={dbServer};Port=5999;Database={dbName};User Id={dbUser};Password={dbPassword};";
            services.AddDbContext<PostgresDbContext>(opt =>
                opt.UseNpgsql(dbUrl ?? options.ConnectionString));
        }
        else
        {
            services.AddDbContext<PostgresDbContext>(opt =>
                opt.UseNpgsql(options.ConnectionStringDev));
        }
        services.AddPostgresRepositories();
        services.AddQueries();
        services.AddSwagger("E.Stadium.Api.xml", "E Stadium")
            .AddSwaggerExample();
        services.AddDataProtector();
        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        var supportedCultures = new[]
        {
            new CultureInfo("en-US"),
            new CultureInfo("fr"),
            new CultureInfo("km"),
        };

        app.UseForwardedHeaders();

        app.UseErrorHandler()
            .UseMiddleware<AuthorizationRequestHandlerMiddleware>()
            .UseMiddleware<LogMiddleware>()
            //.UseInitializer()
            .UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            })
            //.UseAllForwardedHeaders()
            .UseLogUserIdMiddleware();


        //app.UseMasstransit()
        //    .SubscribeConsumer<StartupSchedule>()
        //    .SubscribeConsumer<RecordSchedule>();

        return app;
    }

    //public static IApplicationBuilder UseAllForwardedHeaders(this IApplicationBuilder builder)
    //    => builder.UseForwardedHeaders(new ForwardedHeadersOptions
    //    {
    //        ForwardedHeaders = ForwardedHeaders.All
    //    });

    public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
        => builder.UseMiddleware<ErrorHandlerMiddleware>();

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

    public static IApplicationBuilder UseLogUserIdMiddleware(this IApplicationBuilder builder)
        => builder.UseMiddleware<LogUserIdMiddleware>();
}
