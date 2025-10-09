namespace PatientService.Domain.Entities.Patients;

public class Patient
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string DateOfBirth { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PrimaryPhone { get; set; } = string.Empty;

    public string SecondaryPhone { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string BloodGroup { get; set; } = string.Empty;

    public float Height { get; set; }

    public float Weight { get; set; }

    public byte[]? Photo{get; set; }

}
