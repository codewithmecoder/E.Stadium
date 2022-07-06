using E.Stadium.Infrastructure.Postgres.User;
using Microsoft.EntityFrameworkCore;

namespace E.Stadium.Infrastructure.Postgres;

public class PostgresDbContext : DbContext
{
    public DbSet<UserTable> Users { get; set; } = null!;


    public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



        //modelBuilder.Entity<FarmActivityLogTable>().Property(x => x.Idx)
        //    .UseIdentityAlwaysColumn()
        //    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        //modelBuilder.Entity<NotificationTable>().Property(x => x.Idx)
        //    .UseIdentityAlwaysColumn()
        //    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        //modelBuilder.Entity<UserTable>().HasKey(i => i.Id);

        //modelBuilder.Entity<ScheduleTable>()
        //    .HasMany(sch => sch.Records)
        //    .WithMany(rec => rec.Schedules)
        //    .UsingEntity<ScheduleRecordTable>(
        //    j => j
        //        .HasOne(pt => pt.Record)
        //        .WithMany(t => t.ScheduleRecords)
        //        .HasForeignKey(pt => pt.RecordId),
        //    j => j
        //        .HasOne(pt => pt.Schedule)
        //        .WithMany(p => p.ScheduleRecords)
        //        .HasForeignKey(pt => pt.ScheduleId),
        //    j =>
        //    {
        //        //j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        //        j.HasKey(t => new { t.ScheduleId, t.RecordId });
        //    });

        ////modelBuilder.Entity<ScheduleCategoryTable>()
        ////    .HasMany(sc => sc.Records)
        ////    .WithMany(fr => fr.ScheduleCategories)
        ////    .UsingEntity<ScheduleRecordTable>(
        ////        configureRight: x => x.HasOne(t=>t.Record).WithMany(t=>t.ScheduleRecords).HasForeignKey(t=>t.RecordId),
        ////        configureLeft: x => x.HasOne(t=>t.ScheduleCategory).WithMany(t=>t.ScheduleRecords).HasForeignKey(t=>t.CategoryId),
        ////        configureJoinEntityType: x =>
        ////        {
        ////            x.HasKey(t => new { t.CategoryId,t.RecordId});
        ////        }
        ////        );

        //modelBuilder.Entity<ScheduleTable>()
        //   .HasMany(sch => sch.Users)
        //   .WithMany(rec => rec.Schedules)
        //   .UsingEntity<ScheduleUserTable>(
        //   j => j
        //       .HasOne(pt => pt.User)
        //       .WithMany(t => t.ScheduleUsers)
        //       .HasForeignKey(pt => pt.UserId),
        //   j => j
        //       .HasOne(pt => pt.Schedule)
        //       .WithMany(p => p.ScheduleUsers)
        //       .HasForeignKey(pt => pt.ScheduleId),
        //   j =>
        //   {
        //       //j.Property(pt => pt.PublicationDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        //       j.HasKey(t => new { t.ScheduleId, t.UserId });
        //   });

        //modelBuilder.Entity<ScheduleTable>()
        //  .HasOne(rec => rec.FarmCategory)
        //  .WithMany(cat => cat.Schedules)
        //  .HasForeignKey(rec => rec.CategoryId);

        //modelBuilder.Entity<ScheduleTable>()
        //  .HasMany(rec => rec.ScheduleCompletes)
        //  .WithOne(cat => cat.Schedule)
        //  .HasForeignKey(rec => rec.ScheduleId);
        //modelBuilder.Entity<ScheduleTable>()
        //  .HasMany(rec => rec.ScheduleCategories)
        //  .WithOne(cat => cat.Schedule)
        //  .HasForeignKey(rec => rec.ScheduleId);

        //modelBuilder.Entity<FarmRecordTable>()
        //    .HasOne(rec => rec.FarmCategory)
        //    .WithMany(cat => cat.Records)
        //    .HasForeignKey(rec => rec.FarmCategoryId);

        //modelBuilder.Entity<SaleTable>()
        //  .HasMany(rec => rec.SaleDetails)
        //  .WithOne(cat => cat.Sale)
        //  .HasForeignKey(rec => rec.SaleId);

        ////modelBuilder.Entity<ScheduleRecordTable>()
        ////    .HasKey(sr => new { sr.SchedulId, sr.RecordId });

        ////modelBuilder.Entity<ScheduleRecordTable>()
        ////    .HasOne(sr => sr.Schedule)
        ////    .WithMany(s => s.ScheduleRecords)
        ////    .HasForeignKey(sr => sr.SchedulId);

        ////modelBuilder.Entity<ScheduleRecordTable>()
        ////   .HasOne(sr => sr.Record)
        ////   .WithMany(s => s.ScheduleRecords)
        ////   .HasForeignKey(sr => sr.RecordId);

        //modelBuilder.AddSaleDetailRecordRelationship();
        //modelBuilder.AddSaleFarmRelationship();
        //modelBuilder.AddRecordMediaRelationship();


        //modelBuilder.Entity<SummaryReportEntity>().HasNoKey();
    }
}
