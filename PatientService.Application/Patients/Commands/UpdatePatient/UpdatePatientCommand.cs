using ErrorOr;
using PatientService.Application.Common.Interfaces;

namespace PatientService.Application.Patients.Commands.UpdatePatient;

public record UpdatePatientCommand(UpdatePatientRequest PatientRequest): IAuthorizeableRequest<ErrorOr<Success>>;
