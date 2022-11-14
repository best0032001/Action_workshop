using System.Linq.Expressions;

namespace workshop.QueryableExtensions
{
    public static class QueryableExtensions
    {
        /// Used for paging. Can be used as an alternative to Skip(...).Take(...) chaining.
        /// </summary>
        public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            return query.Skip(skipCount).Take(maxResultCount);
        }
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                         int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.TotalItems = query.Count();


            var pageCount = (double)result.TotalItems / pageSize;
            result.TotalPages = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Rows = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}
