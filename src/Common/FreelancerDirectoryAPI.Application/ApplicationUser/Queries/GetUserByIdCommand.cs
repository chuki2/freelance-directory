using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using MediatR;


namespace FreelancerDirectoryAPI.Application.ApplicationUser.Queries
{
    public class GetUserByIdCommand : IRequest<ServiceResult<ApplicationUserDto>>
    {
        public string Id { get; set; }       
    }
}
