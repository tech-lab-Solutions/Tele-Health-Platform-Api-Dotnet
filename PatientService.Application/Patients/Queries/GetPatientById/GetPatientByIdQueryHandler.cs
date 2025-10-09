using ErrorOr;
using FreeMediator;
using Mapster;
using PatientService.Application.Common.Interfaces;
using PatientService.Application.Dtos;

namespace PatientService.Application.Patients.Queries.GetPatientById;

public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, ErrorOr<PatientDto>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientByIdQueryHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<ErrorOr<PatientDto>> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var patient = await _patientRepository.GetByIdAsync(query.Id);

        if (patient is null)
        {
            return Error.NotFound(description: $"Patient with ID {query.Id} not found.");
        }

        var patientDto = patient.Adapt<PatientDto>();
        return patientDto;
    }
}