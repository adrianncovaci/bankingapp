using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class LoanRequestStatus {
        public int LoanRequestStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
