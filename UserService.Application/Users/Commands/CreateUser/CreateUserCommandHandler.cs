using ErrorOr;
using FreeMediator;
using Mapster;
using UserService.Application.Common.Interfaces;
using UserService.Domain.Entities.Users;

namespace UserService.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(IUserRepository UserRepository): IRequestHandler<CreateUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.UserRequest;

        var user = request.Adapt<User>();

        await UserRepository.AddAsync(user);   
        await UserRepository.SaveChangesAsync();

        return Result.Success;
    }
}