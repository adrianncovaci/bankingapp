using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankingApp.API.Models.Pagination;
using BankingApp.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Infrastructure.Extensions
{
    public static class PaginationQuery
    {
        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest request)
        {
            var predicate = new StringBuilder();
            var filters = request.RequestFilters;

            if (filters == null) return query;

            for (int i = 0; i < filters.Filters.Count; i++)
            {
                if (i > 0)
                {
                    predicate.Append($" {filters.FilterOperators} ");
                }
                predicate.Append(filters.Filters[i].Path + $".{nameof(string.Contains)}(@{i.ToString()})");
            }

            if (filters.Filters.Any())
            {
                var props = filters.Filters.Select(filter => filter.Value).ToArray();
                query = query.Where(predicate.ToString(), props);
            }
            return query;
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.ColumnNameForSorting))
            {
                query = query.OrderBy($"{request.ColumnNameForSorting} {request.SortDirection}");
            }
            return query;
        }

        private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest request)
        {
            var entities = query.Skip((request.PageIndex) * request.PageSize).Take(request.PageSize);
            return entities;
        }

        public async static Task<PagedResponse<TModel>> CreatePaginatedResultAsync<T, TModel>(this IQueryable<T> query, PagedRequest request, IMapper mapper)
        where T : BaseEntity where TModel : class
        {
            query = query.ApplyFilters(request);
            var count = await query.CountAsync();
            query = query.Paginate(request);
            var projectedResult = query.ProjectTo<TModel>(mapper.ConfigurationProvider);
            projectedResult = projectedResult.Sort(request);
            var listResult = await projectedResult.ToListAsync();

            return new PagedResponse<TModel>()
            {
                Data = listResult,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Total = count
            };
        }
    }
}