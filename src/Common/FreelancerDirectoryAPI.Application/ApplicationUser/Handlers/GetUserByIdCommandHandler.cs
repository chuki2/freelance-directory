using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Handlers
{
    public class GetUserByIdCommandHandler : IRequestHandler<GetUserByIdCommand, ServiceResult<ApplicationUserDto>>
    {
        private readonly UserManager<Domain.Entities.ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetUserByIdCommandHandler(UserManager<Domain.Entities.ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ApplicationUserDto>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            // Retrieve the user by Id
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                return ServiceResult.Failed<ApplicationUserDto>(ServiceError.CustomMessage("No user found with this ID."));
            }

            // Map the user entity to DTO
            var userDto = _mapper.Map<ApplicationUserDto>(user);

            // Return successful result with user data
            return ServiceResult<ApplicationUserDto>.Success(userDto);
        }
    }
}
