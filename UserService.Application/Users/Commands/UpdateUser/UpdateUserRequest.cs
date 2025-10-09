using UserService.Domain.Enums;

namespace UserService.Application.Users.Commands.UpdateUser;

public class UpdateUserRequest
{ 
    public int UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public UserType Type { get; set; }
}
