using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using Mapster;
using System.Collections.Generic;
using System.Linq;

namespace FreelancerDirectoryAPI.Application.Common.Mapping
{
    public static class MapsterConfig
    {
        public static void Configure()
        {
            TypeAdapterConfig<Domain.Entities.ApplicationUser, ApplicationUserDto>.NewConfig()
                .Map(dest => dest.Skillsets, src => src.Skillsets == null ? new List<string>() : src.Skillsets.Split(new[] { ',' }).ToList());
        }
    }
}
