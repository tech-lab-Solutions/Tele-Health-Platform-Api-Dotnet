using ErrorOr;
using PatientService.Application.Common.Interfaces;

namespace PatientService.Application.Patients.Commands.UploadPatientPhoto;

public record UploadPatientPhotoCommand(UploadPatientPhotoRequest PhotoRequest)
    : IAuthorizeableRequest<ErrorOr<Success>>;
