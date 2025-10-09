using ErrorOr;
using PatientService.Application.Common.Interfaces;

namespace PatientService.Application.Patients.Commands.CreatePatient;

public record CreatePatientCommand(CreatePatientRequest PatientRequest) : IAuthorizeableRequest<ErrorOr<Success>>;
