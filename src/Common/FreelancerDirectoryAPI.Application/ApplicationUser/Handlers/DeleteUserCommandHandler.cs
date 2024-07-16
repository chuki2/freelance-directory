using FreelancerDirectoryAPI.Application.ApplicationUser.Commands;
using FreelancerDirectoryAPI.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Handlers
{  

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ServiceResult>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;

        public DeleteUserCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ServiceResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return ServiceResult.Failed(ServiceError.CustomMessage("No user found with this ID."));
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return ServiceResult.Failed(ServiceError.CustomMessage("Failed to delete user."));
            }

            return ServiceResult.Success();
        }
    }

}
