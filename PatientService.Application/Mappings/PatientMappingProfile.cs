using Mapster;
using PatientService.Application.Dtos;
using PatientService.Application.Patients.Commands.CreatePatient;
using PatientService.Application.Patients.Commands.UpdatePatient;
using PatientService.Domain.Entities.Patients;

namespace PatientService.Application.Mappings;

public static class PatientMappingProfile
{
    public static void RegisterPatientMappings()
    {
        TypeAdapterConfig<CreatePatientRequest, CreatePatientCommand>.NewConfig();
        TypeAdapterConfig<UpdatePatientRequest, UpdatePatientCommand>.NewConfig();

        //Entity → DTO mapping
        TypeAdapterConfig<Patient, PatientDto>.NewConfig();
    }
}

