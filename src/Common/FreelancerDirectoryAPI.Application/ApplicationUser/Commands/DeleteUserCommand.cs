using FreelancerDirectoryAPI.Application.Common.Models;
using MediatR;
using System;

namespace FreelancerDirectoryAPI.Application.ApplicationUser.Commands
{
    public class DeleteUserCommand : IRequest<ServiceResult>
    {
        public string Id { get; set; }

      
    }
}
