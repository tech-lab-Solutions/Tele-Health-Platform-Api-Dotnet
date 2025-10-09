namespace DoctorService.Domain.Entities.Doctors;

public class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string Qualification { get; set; } = string.Empty;

    public string Hospital { get; set; } = string.Empty;

    public string Experience { get; set; } = string.Empty;

    public string Languages { get; set; } = string.Empty;

    public string Availability { get; set; } = string.Empty;

    public string Timings { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public double Rating { get; set; }

    public decimal Fee { get; set; }

    public ICollection<Specialization> Specializations { get; set; } = [];

    public ICollection<Treatment> Treatments { get; set; } = [];
}
