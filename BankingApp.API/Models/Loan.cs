using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class Loan {
        public int LoanId { get; set; }
        public decimal InterestRate { get; set; }
        public int Period { get; set; }

        public int LoanTypeId { get; set; }
        public LoanType LoanType { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
