using E.Stadium.Infrastructure.Postgres.FileUploads;
using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Infrastructure.Postgres.User;
using E.Stadium.Shared.Postgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace E.Stadium.Infrastructure.Postgres;

public static class Extensions
{
    public static IServiceCollection AddPostgresRepositories(this IServiceCollection services)
    {
        services.AddPostgresRepository<UserTable>();
        services.AddPostgresRepository<StadiumTable>();
        services.AddPostgresRepository<FieldTable>();
        services.AddPostgresRepository<StadiumMediaTable>();
        services.AddPostgresRepository<FieldMediaTable>();

        //services.AddTransient<IDbRepository, DbRepository>(sp =>
        //{
        //    var options = services.BuildServiceProvider().GetRequiredService<DbContextOptions<PostgresDbContext>>();
        //    return new DbRepository(new PostgresDbContext(options));
        //});

        //services.AddTransient<IReportRepository, ReportRepository>(sp =>
        //{
        //    var context = services.BuildServiceProvider().GetRequiredService<PostgresDbContext>();
        //    return new ReportRepository(context);
        //});

        return services;
    }

    public static IServiceCollection AddPostgresRepository<TTable>(this IServiceCollection services) where TTable : BasePostgresTable
    {
        services.AddTransient<IPostgresRepository<TTable>>(sp =>
        {
            var options = services.BuildServiceProvider().GetService<DbContextOptions<PostgresDbContext>>();
            return new PostgresRepository<TTable>(new PostgresDbContext(options!));
        });

        return services;
    }
}
