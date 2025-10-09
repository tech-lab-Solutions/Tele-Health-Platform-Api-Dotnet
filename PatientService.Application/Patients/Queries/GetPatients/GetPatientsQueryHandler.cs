using ErrorOr;
using FreeMediator;
using Mapster;
using PatientService.Application.Common.Interfaces;
using PatientService.Application.Dtos;

namespace PatientService.Application.Patients.Queries.GetPatients;

public class GetPatientsQueryHandler(IPatientRepository patientRepository) : IRequestHandler<GetPatientsQuery, ErrorOr<List<PatientDto>>>
{
    public async Task<ErrorOr<List<PatientDto>>> Handle(GetPatientsQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var patients = await patientRepository.GetAllAsync();

        if (patients is null || !patients.Any())
        {
            return Error.NotFound(description: "No patients found.");
        }

        var Patients = patients
            .OrderBy(p => p.Id)
            .Adapt<List<PatientDto>>();

        return Patients;
    }
}
