using ErrorOr;
using FreeMediator;
using Mapster;
using PatientService.Application.Common.Interfaces;
using PatientService.Domain.Entities.Patients;

namespace PatientService.Application.Patients.Commands.CreatePatient;

public class CreatePatientCommandHandler(IPatientRepository PatientRepository)
    : IRequestHandler<CreatePatientCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.PatientRequest;

        var patient = request.Adapt<Patient>();

        await PatientRepository.AddAsync(patient);
        await PatientRepository.SaveChangesAsync();

        return Result.Success;
    }
}
