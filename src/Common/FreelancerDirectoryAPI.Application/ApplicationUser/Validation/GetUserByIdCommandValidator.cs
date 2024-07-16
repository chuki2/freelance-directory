using FluentValidation;
using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using System;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Validation
{
    public class GetUserByIdCommandValidator : AbstractValidator<GetUserByIdCommand>
    {
        public GetUserByIdCommandValidator()
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("User ID must not be empty.");
        }

       
    }
}
