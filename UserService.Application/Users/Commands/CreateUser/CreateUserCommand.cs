using ErrorOr;
using UserService.Application.Common.Interfaces;

namespace UserService.Application.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserRequest UserRequest) : IAuthorizeableRequest<ErrorOr<Success>>;