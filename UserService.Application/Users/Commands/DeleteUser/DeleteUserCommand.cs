using ErrorOr;
using UserService.Application.Common.Interfaces;

namespace UserService.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(int UserId,DeleteUserRequest UserRequest) : IAuthorizeableRequest<ErrorOr<Success>>;