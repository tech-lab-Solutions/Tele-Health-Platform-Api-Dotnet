using PatientService.Application.Common.Interfaces;
using PatientService.Domain.Entities.Patients;
using PatientService.Infrastructure.Common.Persistence;

namespace PatientService.Infrastructure.Repositories;

public class PatientRepository(PatientServiceDbContext context) : Repository<Patient>(context), IPatientRepository;
