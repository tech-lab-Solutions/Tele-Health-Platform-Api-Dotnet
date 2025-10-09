using ErrorOr;
using FreeMediator;
using PatientService.Application.Dtos;

namespace PatientService.Application.Patients.Queries.GetPatients;

public record GetPatientsQuery : IRequest<ErrorOr<List<PatientDto>>>;

