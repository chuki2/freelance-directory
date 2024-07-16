using System.Threading.Tasks;
using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using Microsoft.AspNetCore.Mvc;

namespace FreelancerDirectoryAPI.Api.Controllers
{
    public class LoginController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<ServiceResult<ApplicationUserTokenDto>>> Create(GetTokenQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
