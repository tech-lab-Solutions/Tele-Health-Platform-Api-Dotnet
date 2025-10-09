namespace PatientService.Application.Patients.Commands.UploadPatientPhoto;

public class UploadPatientPhotoRequest
{
    public int PatientId { get; set; }
    public byte[] Photo { get; set; } = Array.Empty<byte>();
}
