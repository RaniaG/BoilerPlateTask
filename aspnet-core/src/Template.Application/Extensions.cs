using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
namespace Template
{
    public static class Extensions
    {
        public static IQueryable<T> Paging<T>(this ApplicationService self, IQueryable<T> query, IPagedAndSortedResultRequest input)
        {
            if (input.SkipCount != 0)
                query = query.Skip(input.SkipCount);
            if (input.MaxResultCount > 0)
                query = query.Take(input.MaxResultCount);
            return query;

        }
        public static IQueryable<T> Sorting<T>(this ApplicationService self, IQueryable<T> query, SortingAndPagingDTO input)
        {
            //Try to sort query if available
            //var sortInput = input as ISortedResultRequest;

            if (input != null)
            {
                if (!input.Sorting.IsNullOrWhiteSpace())
                {
                    StringBuilder sortQuery = new StringBuilder(input.Sorting);
                    if (input.SortingDirection == SortDirection.desc)
                        sortQuery.Append(" descending");


                    return query.OrderBy(sortQuery.ToString());

                }
            }

            ////IQueryable.Task requires sorting, so we should sort if Take will be used.
            //if (input is ILimitedResultRequest)
            //{
            //    return query.OrderByDescending(e => e.Id);
            //}

            //No sorting
            return query;
        }

    }
}
