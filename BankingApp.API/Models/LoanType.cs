using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class LoanType {
        public int LoanTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}
