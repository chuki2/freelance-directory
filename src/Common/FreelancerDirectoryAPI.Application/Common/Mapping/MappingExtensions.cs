﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelancerDirectoryAPI.Application.Common.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace FreelancerDirectoryAPI.Application.Common.Mapping
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageNumber, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, TypeAdapterConfig configuration)
            => queryable.ProjectToType<TDestination>(configuration).ToListAsync();
    }
}
