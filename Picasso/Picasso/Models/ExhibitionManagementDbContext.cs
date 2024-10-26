using Picasso.Model;
using Microsoft.EntityFrameworkCore;

namespace Picasso.Models
{
    public class ExhibitionManagementDbContext : DbContext
    {
        public ExhibitionManagementDbContext(DbContextOptions<ExhibitionManagementDbContext> options): base(options)
        {
        }

        public DbSet<Administrators> Administrators { get; set; }

        public DbSet<Members> Members { get; set; }

        public DbSet<Spaces> Spaces { get; set; }

        public DbSet<Exhibitions> Exhibitions { get; set; }

        public DbSet<ExhibitionApply> ExhibitionApply { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrators>(entity =>
            {
                entity.Property(e => e.AdministratorId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.AdministratorAccount).IsRequired().HasMaxLength(20);
                entity.Property(e => e.AdministratorPassword).IsRequired().HasMaxLength(20);
                entity.Property(e => e.AdministratorName).IsRequired().HasMaxLength(12);
                entity.Property(e => e.AdministratorPhone).IsRequired().HasMaxLength(10);
                entity.Property(e => e.AdministratorEmail).IsRequired().HasMaxLength(30);
                entity.Property(e => e.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.MemberId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.MemberAccount).IsRequired().HasMaxLength(20);
                entity.Property(e => e.MemberPassword).IsRequired().HasMaxLength(20);
                entity.Property(e => e.MemberName).IsRequired().HasMaxLength(12);
                entity.Property(e => e.MemberIdentity).IsRequired().HasMaxLength(10);
                entity.Property(e => e.MemberPhone).IsRequired().HasMaxLength(10);
                entity.Property(e => e.MemberEmail).IsRequired().HasMaxLength(30);
                entity.Property(e => e.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Spaces>(entity =>
            {
                entity.Property(e => e.SpaceId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.SpaceName).IsRequired().HasMaxLength(10);
                entity.Property(e => e.SpaceLocation).IsRequired().HasMaxLength(30);
                entity.Property(e => e.SpaceDescription).IsRequired().HasMaxLength(500);
                entity.Property(e => e.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<Exhibitions>(entity =>
            {
                entity.Property(e => e.ExhibitionId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.ExhibitionName).IsRequired().HasMaxLength(30);
                entity.Property(e => e.ExhibitionType).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Organizer).IsRequired().HasMaxLength(20);
                entity.Property(e => e.CoOrganizer).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ExhibitionDescription).IsRequired().HasMaxLength(500);
                entity.Property(e => e.ExhibitionStatus).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Image).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });

            modelBuilder.Entity<ExhibitionApply>(entity =>
            {
                entity.Property(e => e.ApplyId).HasDefaultValueSql("(newid())");
                entity.Property(e => e.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
            });
        }
    }
}