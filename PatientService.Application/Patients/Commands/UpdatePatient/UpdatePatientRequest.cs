namespace PatientService.Application.Patients.Commands.UpdatePatient;

public class UpdatePatientRequest
{
    public int Id { get; set; }  

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string DateOfBirth { get; set; } = string.Empty;

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? PrimaryPhone { get; set; }

    public string? SecondaryPhone { get; set; }

    public string? Address { get; set; }

    public string? BloodGroup { get; set; }

    public float? Height { get; set; }

    public float? Weight { get; set; }
}
