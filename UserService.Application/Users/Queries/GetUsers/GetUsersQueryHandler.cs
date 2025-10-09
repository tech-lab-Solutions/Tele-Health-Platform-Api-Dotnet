using ErrorOr;
using FreeMediator;
using Mapster;
using UserService.Application.Common.Interfaces;
using UserService.Application.Dtos;

namespace UserService.Application.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUserRepository UserRepository) : IRequestHandler<GetUsersQuery, ErrorOr<List<UserDto>>>
{
    public async Task<ErrorOr<List<UserDto>>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var Users = await UserRepository.GetAllAsync();

        var result = Users.Adapt<List<UserDto>>();

        return result;
    }
}