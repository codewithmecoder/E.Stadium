using E.Stadium.Infrastructure.Postgres.FileUploads;
using E.Stadium.Infrastructure.Postgres.Stadiums;
using E.Stadium.Infrastructure.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace E.Stadium.Infrastructure.Postgres;

public class PostgresDbContext : DbContext
{
    public DbSet<UserTable> Users { get; set; } = null!;
    public DbSet<StadiumTable> Stadiums { get; set; } = null!;
    public DbSet<FieldTable> Fields { get; set; } = null!;
    public DbSet<FieldMediaTable> FieldMedias { get; set; } = null!;
    public DbSet<StadiumMediaTable> StadiumMedias { get; set; } = null!;


    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.Entity<StadiumTable>()
        //  .HasMany(rec => rec.StadiumMedias)
        //  .WithOne();
        //modelBuilder.Entity<StadiumTable>()
        //  .HasMany(rec => rec.Fields)
        //  .WithOne();

        modelBuilder.Entity<StadiumMediaTable>()
          .HasOne(rec => rec.Stadium)
          .WithMany(i=> i.StadiumMedias)
          .HasForeignKey(rec => rec.StadiumId);

        modelBuilder.Entity<FieldTable>()
          .HasOne(rec => rec.Stadium)
          .WithMany(i=> i.Fields)
          .HasForeignKey(rec => rec.StadiumId);

        modelBuilder.Entity<FieldMediaTable>()
          .HasOne(rec => rec.Field)
          .WithMany(i=> i.FieldMedias)
          .HasForeignKey(rec => rec.FieldId);
    }
}
