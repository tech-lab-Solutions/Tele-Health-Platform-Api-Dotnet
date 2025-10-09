using DoctorService.Application.Common.Interfaces;
using DoctorService.Domain.Entities.Doctors;
using DoctorService.Infrastructure.Common.Persistence;

namespace DoctorService.Infrastructure.Repositories;

public class DoctorRepository(DoctorServiceDbContext context) : Repository<Doctor>(context), IDoctorRepository;
