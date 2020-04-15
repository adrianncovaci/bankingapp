using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class LoanType {
        public int LoanTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
