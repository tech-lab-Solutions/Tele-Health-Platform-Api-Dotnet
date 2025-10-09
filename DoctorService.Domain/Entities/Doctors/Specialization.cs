namespace DoctorService.Domain.Entities.Doctors;

public class Specialization
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
}

