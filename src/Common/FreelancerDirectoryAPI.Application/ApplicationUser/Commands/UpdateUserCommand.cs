using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace FreelancerDirectoryAPI.Application.ApplicationUser.Commands
{
    public class UpdateUserCommand : IRequest<ServiceResult<ApplicationUserDto>>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Skillsets { get; set; }
        public string Hobby { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ServiceResult<ApplicationUserDto>>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if the user exists
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {

                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.CustomMessage("No user found with this email address."));
            }
        

            // Update user details
            user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            user.Hobby = request.Hobby;

            // Convert Skillsets List to comma-separated string
            user.Skillsets = request.Skillsets != null ? string.Join(",", request.Skillsets) : string.Empty;

            // Attempt to update the user in the database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.CustomMessage("Failed to update user. " + string.Join("; ", result.Errors.Select(e => e.Description))));

            }

            // Map updated user to DTO
            var userDto = _mapper.Map<ApplicationUserDto>(user);

            // Successfully updated the user
            return ServiceResult<ApplicationUserDto>.Success(userDto);
        }
    }

}
