namespace workshop.QueryableExtensions
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public int FirstRowOnPage
        {

            get { return (CurrentPage - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(CurrentPage * PageSize, TotalItems); }
        }
    }
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Rows { get; set; }

        public PagedResult()
        {
            Rows = new List<T>();
        }
    }

}
