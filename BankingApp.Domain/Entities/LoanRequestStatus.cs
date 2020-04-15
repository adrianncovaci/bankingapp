using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class LoanRequestStatus {
        public int LoanRequestStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
