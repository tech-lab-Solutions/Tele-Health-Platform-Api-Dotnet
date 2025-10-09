using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PatientService.Domain.Entities.Patients;

namespace PatientService.Infrastructure.Common.Persistence;

public class PatientServiceDbContext(DbContextOptions<PatientServiceDbContext> options) : DbContext(options)
{
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
}
