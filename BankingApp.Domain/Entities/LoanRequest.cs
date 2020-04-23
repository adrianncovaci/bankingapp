using System;

namespace BankingApp.Domain.Entities {
    public class LoanRequest: BaseEntity {
        public DateTime DateIssued { get; private set; } = DateTime.Now;
        public string Comments { get; set; }
        public DateTime? ResponseDate { get; set; }

        public int LoanRequestStatusId { get; set; }
        public LoanRequestStatus LoanRequestStatus { get; set; }

        public int LoanOfficerId { get; set; }
        public LoanOfficer LoanOfficer { get; set; }

        public int AccountId { get; set; }
        public BankAccount Account { get; set; }

        public int LoanId { get; set; }
        public Loan Loan { get; set; }
    }
}
