using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;


namespace CarModelManagement_CommonServices.Context.CarModelManagementModel
{
    public partial class CarsContext : DbContext
    {
        public CarsContext()
        {
        }
        public CarsContext(DbContextOptions<CarsContext> options)
           : base(options)
        {
        }
        public virtual DbSet<Cars> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.191;Database= test;user Id=test;password=qwer1234;Persist Security Info=True;");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ModelCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Features)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.Price)
                    .IsRequired();

                entity.Property(e => e.ManufacturedOn)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired();

                entity.Property(e => e.IsDeleted)
                    .IsRequired();

                //entity.Property(e => e.SortOrder)
                //    .IsRequired();

                //entity.Property(e => e.Images)
                //    .IsRequired()
                //    .HasColumnType("nvarchar(max)");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
