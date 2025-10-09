using ErrorOr;
using UserService.Application.Common.Interfaces;

namespace UserService.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(int UserId, UpdateUserRequest UserRequest) : IAuthorizeableRequest<ErrorOr<Success>>;