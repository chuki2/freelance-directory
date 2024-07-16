using FluentValidation;
using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Validation
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(command => command.Id)
               .NotEmpty().WithMessage("User ID must not be empty.");

            RuleFor(command => command.UserName)
                .NotEmpty().WithMessage("Username is required.");

            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Email address is not in a valid format.");

        }

       
    }
}
