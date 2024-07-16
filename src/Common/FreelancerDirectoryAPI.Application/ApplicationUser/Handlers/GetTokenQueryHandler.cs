using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using System.Threading;
using System.Threading.Tasks;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Handlers
{
    public class GetTokenQueryHandler : IRequestHandlerWrapper<GetTokenQuery, ApplicationUserTokenDto>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;

        public GetTokenQueryHandler(IIdentityService identityService, ITokenService tokenService)
        {
            _identityService = identityService;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult<ApplicationUserTokenDto>> Handle(GetTokenQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.CheckUserPassword(request.Email, request.Password);

            if (user == null)
                return ServiceResult.Failed<ApplicationUserTokenDto>(ServiceError.ForbiddenError);


            return ServiceResult.Success(new ApplicationUserTokenDto
            {
                User = user,
                Token = _tokenService.CreateJwtSecurityToken(user.Id)
            });
        }

    }
}
