using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreelancerDirectoryAPI.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Skillsets { get; set; }
        public string Hobby { get; set; }
    }
}
