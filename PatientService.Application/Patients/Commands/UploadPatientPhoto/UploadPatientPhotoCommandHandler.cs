using ErrorOr;
using FreeMediator;
using PatientService.Application.Common.Interfaces;

namespace PatientService.Application.Patients.Commands.UploadPatientPhoto;

public class UploadPatientPhotoCommandHandler(IPatientRepository patientRepository): IRequestHandler<UploadPatientPhotoCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UploadPatientPhotoCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.PhotoRequest;

        var patient = await patientRepository.GetByIdAsync(request.PatientId);
        if (patient is null)
            return Error.NotFound(description: "Patient not found");

        if (patient.Photo != null && request.Photo != null)
        {
            patient.Photo = request.Photo;
        }
        else if (patient.Photo == null && request.Photo != null)
        {
            patient.Photo = request.Photo;
        }
        else
        {
            return Error.Validation(description: "No photo data provided.");
        }
        await patientRepository.SaveChangesAsync();

        return Result.Success;
    }
}