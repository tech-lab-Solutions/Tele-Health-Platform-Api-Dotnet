using ErrorOr;
using FreeMediator;
using Mapster;
using UserService.Application.Common.Interfaces;

namespace UserService.Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(IUserRepository UserRepository): IRequestHandler<UpdateUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.UserRequest;

        var User = await UserRepository.GetByIdAsync(request.UserId);
        if (User is null)
        {
            return Error.NotFound("User not found.");

        }

        request.Adapt(User);

        UserRepository.Update(User);
        await UserRepository.SaveChangesAsync();

        return Result.Success;
    }
}