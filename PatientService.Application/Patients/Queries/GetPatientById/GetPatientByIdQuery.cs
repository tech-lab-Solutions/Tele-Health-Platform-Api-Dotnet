using ErrorOr;
using FreeMediator;
using PatientService.Application.Dtos;

namespace PatientService.Application.Patients.Queries.GetPatientById;

public record GetPatientByIdQuery(int Id) : IRequest<ErrorOr<PatientDto>>;

