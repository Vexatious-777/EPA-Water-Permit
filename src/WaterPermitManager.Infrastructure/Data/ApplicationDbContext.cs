using Microsoft.EntityFrameworkCore;
using WaterPermitManager.Core.Models;

namespace WaterPermitManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<WaterPermit> WaterPermits { get; set; }
        public DbSet<PermitParameter> PermitParameters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WaterPermit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PermitNumber).IsRequired();
                entity.Property(e => e.FacilityName).IsRequired();
                entity.Property(e => e.FacilityAddress).IsRequired();
                entity.Property(e => e.WaterSourceType).IsRequired();
                entity.Property(e => e.AllowedDailyDischarge).HasPrecision(18, 4);
                entity.Property(e => e.DischargeUnit).IsRequired();
                entity.Property(e => e.IssuingAuthority).IsRequired();
            });

            modelBuilder.Entity<PermitParameter>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.LimitValue).HasPrecision(18, 4);
                entity.Property(e => e.Unit).IsRequired();
                entity.Property(e => e.MonitoringFrequency).IsRequired();
                entity.Property(e => e.SampleType).IsRequired();
            });
        }
    }
} 