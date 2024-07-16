using System;
using FreelancerDirectoryAPI.Application.Common.Interfaces;

namespace FreelancerDirectoryAPI.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now.ToUniversalTime();
    }
}
