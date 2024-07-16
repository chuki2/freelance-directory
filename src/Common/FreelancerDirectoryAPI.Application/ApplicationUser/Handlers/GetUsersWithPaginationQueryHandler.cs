using FreelancerDirectoryAPI.Application.ApplicationUser.Queries;
using FreelancerDirectoryAPI.Application.Common.Mapping;
using FreelancerDirectoryAPI.Application.Common.Models;
using FreelancerDirectoryAPI.Application.Dto.ApplicationUser;
using FreelancerDirectoryAPI.Domain.Persistence;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace FreelancerDirectoryAPI.Application.ApplicationUser.Handlers
{

    public class GetUsersWithPaginationQueryHandler : IRequestHandler<GetUsersWithPaginationQuery, ServiceResult<PaginatedList<ApplicationUserDto>>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public GetUsersWithPaginationQueryHandler(ApplicationDbContext context, IMapper mapper, IMemoryCache cache)
        {
            _context = context;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<ServiceResult<PaginatedList<ApplicationUserDto>>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            // Generate a unique cache key using hash
            var cacheKey = CacheKeyHelper.GenerateCacheKeyFromParams(new
            {
                request.PageNumber,
                request.PageSize,
                request.Username,
                request.Email,
                request.PhoneNo,
                request.Hobby,
                Skillsets = string.Join(",", request.Skillsets ?? new List<string>())
            });

            if (_cache.TryGetValue(cacheKey, out PaginatedList<ApplicationUserDto> cachedList))
            {
                return cachedList.Items.Any()
                    ? ServiceResult.Success(cachedList)
                    : ServiceResult.Failed<PaginatedList<ApplicationUserDto>>(ServiceError.CustomMessage("No users found."));
            }

            var userQueryable = _context.Users.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(request.Username))
            {
                userQueryable = userQueryable.Where(u => u.UserName.Contains(request.Username));
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                userQueryable = userQueryable.Where(u => u.Email.Contains(request.Email));
            }

            if (!string.IsNullOrWhiteSpace(request.PhoneNo))
            {
                userQueryable = userQueryable.Where(u => u.PhoneNumber.Contains(request.PhoneNo));
            }

            if (!string.IsNullOrWhiteSpace(request.Hobby))
            {
                userQueryable = userQueryable.Where(u => u.Hobby.Contains(request.Hobby));
            }

            if (request.Skillsets != null && request.Skillsets.Any())
            {
                foreach (var skill in request.Skillsets)
                {
                    // Ensure the skill is matched as a whole word, not as a substring
                    userQueryable = userQueryable.Where(u => ("," + u.Skillsets + ",").Contains("," + skill + ","));
                }
            }

            var list = await userQueryable
                .OrderBy(o => o.Id)
                .ProjectToType<ApplicationUserDto>(_mapper.Config)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };

            _cache.Set(cacheKey, list, cacheEntryOptions);

            return list.Items.Any()
                ? ServiceResult.Success(list)
                : ServiceResult.Failed<PaginatedList<ApplicationUserDto>>(ServiceError.CustomMessage("No users found."));
        }
    }

}
