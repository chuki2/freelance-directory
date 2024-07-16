using System.Threading;
using System.Threading.Tasks;
using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Queries
{
    public class GetTokenQuery : IRequestWrapper<ApplicationUserTokenDto>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }

   
}
