namespace BankingApp.API.Models.Pagination
{
    public class PagedRequest
    {
        public PagedRequest(RequestFilters filters)
        {
            RequestFilters = filters;
        }
        public PagedRequest() { }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string ColumnNameForSorting { get; set; }
        public string SortDirection { get; set; }
        public RequestFilters RequestFilters { get; set; }
    }
}