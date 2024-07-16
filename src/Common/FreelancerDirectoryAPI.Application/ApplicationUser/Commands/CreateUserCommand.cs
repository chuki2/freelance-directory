
using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using System.Collections.Generic;


namespace FreelancerDirectoryAPI.Application.ApplicationUser.Commands
{
    public class CreateUserCommand : IRequestWrapper<ApplicationUserDto>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Skillsets { get; set; }
        public string Hobby { get; set; }
    }  

}
