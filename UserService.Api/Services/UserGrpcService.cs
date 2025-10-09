using FreeMediator;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Mapster;
using UserService.Application.Users.Commands.CreateUser;
using UserService.Application.Users.Commands.UpdateUser;
using UserService.Application.Users.Commands.DeleteUser;
using UserService.Application.Users.Queries.GetUsers;

namespace UserService.Api.Services
{
    public class UserGrpcService(IMediator mediator) : UserGrpc.UserGrpcBase
    {
        public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
        {
            var command = new CreateUserCommand(request.Adapt<UserService.Application.Users.Commands.CreateUser.CreateUserRequest>());

            var result = await mediator.Send(command, context.CancellationToken);
            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to create User"));

            return new CreateUserResponse { Message = "User created successfully" };
        }

        public override async Task<GetUsersResponse> GetUsers(Empty request, ServerCallContext context)
        {
            var result = await mediator.Send(new GetUsersQuery(), context.CancellationToken);
            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to fetch Users"));

            var response = new GetUsersResponse
            {
                Users = { result.Value.Adapt<List<UserDto>>() }
            };

            return response;
        }

        public override async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request, ServerCallContext context)
        {
            var appRequest = request.Adapt<UserService.Application.Users.Commands.UpdateUser.UpdateUserRequest>();
            var command = new UpdateUserCommand(request.UserId, appRequest);

            var result = await mediator.Send(command, context.CancellationToken);
            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to update User"));

            return new UpdateUserResponse { Message = "User updated successfully" };
        }

        public override async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
        {
            var appRequest = request.Adapt<UserService.Application.Users.Commands.DeleteUser.DeleteUserRequest>();
            var command = new DeleteUserCommand(request.UserId, appRequest);

            var result = await mediator.Send(command, context.CancellationToken);
            if (result.IsError)
                throw new RpcException(new Status(StatusCode.Internal, "Failed to delete User"));

            return new DeleteUserResponse { Message = "User deleted successfully" };
        }
    }
}
