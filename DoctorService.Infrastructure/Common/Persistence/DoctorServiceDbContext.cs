using DoctorService.Domain.Entities.Doctors;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.Infrastructure.Common.Persistence;

public class DoctorServiceDbContext(DbContextOptions<DoctorServiceDbContext> options) : DbContext(options)
{
    public DbSet<Doctor> Doctors{ get; set; }

    public DbSet<Specialization> Specializations { get; set; }

    public DbSet<Treatment> Treatments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");
            entity.HasKey(d => d.Id);


            entity.Property(d => d.Name).IsRequired();
            entity.Property(d => d.Type).IsRequired();
            entity.Property(d => d.Qualification).HasMaxLength(500);
            entity.Property(d => d.Hospital).HasMaxLength(255);
        });


        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("specializations");
            entity.HasKey(s => s.Id);


            entity.Property(s => s.Name).IsRequired().HasMaxLength(255);


            entity.HasOne(s => s.Doctor)
            .WithMany(d => d.Specializations)
            .HasForeignKey(s => s.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
        });


        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.ToTable("treatments");
            entity.HasKey(t => t.Id);


            entity.Property(t => t.Name).IsRequired().HasMaxLength(255);


            entity.HasOne(t => t.Doctor)
            .WithMany(d => d.Treatments)
            .HasForeignKey(t => t.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);
        });

    }
}
