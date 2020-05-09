using System.Collections.Generic;

namespace BankingApp.API.Models.Pagination {
    public class RequestFilters {
        public RequestFilters() {
            Filters = new List<Filter>();
        }
        public FilterOperators FilterOperators { get; set; }
        public IList<Filter> Filters { get; set; }
    }
}