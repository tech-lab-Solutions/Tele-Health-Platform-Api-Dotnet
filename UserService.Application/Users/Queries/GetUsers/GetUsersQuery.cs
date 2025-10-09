using ErrorOr;
using FreeMediator;
using UserService.Application.Dtos;

namespace UserService.Application.Users.Queries.GetUsers;

public record GetUsersQuery : IRequest<ErrorOr<List<UserDto>>>;


