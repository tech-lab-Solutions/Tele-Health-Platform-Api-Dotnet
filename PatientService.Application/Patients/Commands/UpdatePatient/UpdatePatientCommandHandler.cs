using ErrorOr;
using FreeMediator;
using Mapster;
using PatientService.Application.Common.Interfaces;

namespace PatientService.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientCommandHandler(IPatientRepository patientRepository)
    : IRequestHandler<UpdatePatientCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdatePatientCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.PatientRequest;

        var patient = await patientRepository.GetByIdAsync(request.Id);
        if (patient is null)
        {
            return Error.NotFound("Patient not found.");
        }

        request.Adapt(patient);

        patientRepository.Update(patient);
        await patientRepository.SaveChangesAsync();

        return Result.Success;
    }
}
