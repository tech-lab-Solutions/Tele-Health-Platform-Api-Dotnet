using ErrorOr;
using FreeMediator;
using UserService.Application.Common.Interfaces;

namespace UserService.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(IUserRepository UserRepository): IRequestHandler<DeleteUserCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var request = command.UserRequest;

        var User = await UserRepository.GetByIdAsync(request.UserId);
        if (User is null)
        {
            return Error.NotFound("User not found.");

        }

        UserRepository.Remove(User);

        await UserRepository.SaveChangesAsync();

        return Result.Success;
    }
}