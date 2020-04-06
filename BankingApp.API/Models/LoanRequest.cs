using System;

namespace BankingApp.API.Models {
    public class LoanRequest {
        public int LoanRequestId { get; set; }
        public DateTime DateIssued { get; private set; } = DateTime.Now;
        public string Comments { get; set; }
        public DateTime? ResponseDate { get; set; }

        public int LoanRequestStatusId { get; set; }
        public LoanRequestStatus LoanRequestStatus { get; set; }

        public int LoanOfficerId { get; set; }
        public LoanOfficer LoanOfficer { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
