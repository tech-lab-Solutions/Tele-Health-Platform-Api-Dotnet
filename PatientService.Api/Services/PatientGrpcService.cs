using FreeMediator;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mapster;
using PatientService.Application.Patients.Commands.CreatePatient;
using PatientService.Application.Patients.Commands.UpdatePatient;
using PatientService.Application.Patients.Commands.UploadPatientPhoto;
using PatientService.Application.Patients.Queries.GetPatientById;
using PatientService.Application.Patients.Queries.GetPatients;

namespace PatientService.Api.Services
{
    public class PatientGrpcService(IMediator mediator) : PatientGrpc.PatientGrpcBase
    {
        public override async Task<CreatePatientResponse> CreatePatient(CreatePatientRequest request, ServerCallContext context)
        {
            var command = new CreatePatientCommand(
                request.Adapt<PatientService.Application.Patients.Commands.CreatePatient.CreatePatientRequest>());

            var result = await mediator.Send(command, context.CancellationToken);
            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to create Patient"));

            return new CreatePatientResponse { Message = "Patient created successfully" };
        }

        public override async Task<UploadPatientPhotoResponse> UploadPatientPhoto(UploadPatientPhotoRequest request, ServerCallContext context)
        {
            var command = new UploadPatientPhotoCommand(
                request.Adapt<PatientService.Application.Patients.Commands.UploadPatientPhoto.UploadPatientPhotoRequest>());

            var result = await mediator.Send(command, context.CancellationToken);

            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to upload patient photo"));

            return new UploadPatientPhotoResponse
            {
                Message = "Photo uploaded successfully"
            };
        }

        public override async Task<UpdatePatientResponse> UpdatePatient(UpdatePatientRequest request, ServerCallContext context)
        {
            var command = new UpdatePatientCommand(
                request.Adapt<PatientService.Application.Patients.Commands.UpdatePatient.UpdatePatientRequest>());
            var result = await mediator.Send(command, context.CancellationToken);

            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to update patient"));

            return new UpdatePatientResponse { Message = "Patient updated successfully" };
        }

        public override async Task<GetPatientsResponse> GetPatients(Empty request, ServerCallContext context)
        {
            var query = new GetPatientsQuery();
            var result = await mediator.Send(query, context.CancellationToken);

            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to fetch patients"));

            var response = new GetPatientsResponse();
            response.Patients.AddRange(result.Value.Adapt<IEnumerable<PatientDto>>());

            return response;
        }

        public override async Task<GetPatientByIdResponse> GetPatientById(GetPatientByIdRequest request, ServerCallContext context)
        {
            var query = new GetPatientByIdQuery(request.Id);

            var result = await mediator.Send(query, context.CancellationToken);

            if (result.IsError)
                throw new RpcException(new Status(StatusCode.NotFound, "Patient not found"));

            var response = new GetPatientByIdResponse
            {
                Patient = result.Value.Adapt<PatientDto>()
            };

            return response;
        }
    }
}
