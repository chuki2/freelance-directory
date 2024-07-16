using FreelancerDirectoryAPI.Application.Common.Interfaces;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using System.Collections.Generic;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Queries
{

    public class GetUsersWithPaginationQuery : IRequestWrapper<PaginatedList<ApplicationUserDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;


        public string Username { get; set; }

        public string Email { get; set; }
        public string PhoneNo { get; set; }

        public List<string> Skillsets { get; set; }

        public string Hobby { get; set; }

    }


}
