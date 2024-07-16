using System.Collections.Generic;

namespace FreelancerDirectoryAPI.Application.Dto.ApplicationUser
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Skillsets { get; set; }
        public string Hobby { get; set; }
    }
}
