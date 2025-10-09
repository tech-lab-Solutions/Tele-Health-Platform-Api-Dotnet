namespace PatientService.Application.Dtos;

public class PatientDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Gender { get; set; } = string.Empty;

    public string DateOfBirth { get; set; } = string.Empty;

    public int Age { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string BloodGroup { get; set; } = string.Empty;

    public float Height { get; set; }

    public float Weight { get; set; }

}
