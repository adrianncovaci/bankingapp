using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class LoanRequestStatus: BaseEntity {
        public string Status { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
