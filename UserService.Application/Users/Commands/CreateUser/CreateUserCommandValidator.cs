using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace UserService.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.UserRequest)
           .NotEmpty().NotNull().WithMessage("Bad request.");

        RuleFor(x => x.UserRequest.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.");

        RuleFor(x => x.UserRequest.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.");

        RuleFor(x => x.UserRequest.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Please provide a valid email address.");


        RuleFor(x => x.UserRequest.Phone)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^[0-9]{10}$").WithMessage("Phone number must be exactly 10 digits.");
    }
}
