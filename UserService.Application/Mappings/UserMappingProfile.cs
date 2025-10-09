using Mapster;
using UserService.Application.Dtos;
using UserService.Application.Users.Commands.CreateUser;
using UserService.Application.Users.Commands.DeleteUser;
using UserService.Application.Users.Commands.UpdateUser;
using UserService.Domain.Entities.Users;

namespace UserService.Application.Mappings;

public static class UserMappingProfile
{
    public static void RegisterUserMappings()
    {
        TypeAdapterConfig<CreateUserRequest, CreateUserCommand>.NewConfig();
        TypeAdapterConfig<UpdateUserRequest, UpdateUserCommand>.NewConfig();
        TypeAdapterConfig<DeleteUserRequest, DeleteUserCommand>.NewConfig();

        TypeAdapterConfig<User, UserDto>.NewConfig();
    }
}
