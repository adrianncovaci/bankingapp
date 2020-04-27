using System;

namespace BankingApp.API.Models.Loans {
    public class LoanRequestModel {
        public int LoanId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateIssued { get; set; } = DateTime.Now;
        public string Comments { get; set; }
    }
}
