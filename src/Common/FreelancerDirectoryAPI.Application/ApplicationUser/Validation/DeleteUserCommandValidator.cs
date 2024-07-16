using System;
using FluentValidation;
using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Validation
{


    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("User ID must not be empty.");
        }

    }

}
