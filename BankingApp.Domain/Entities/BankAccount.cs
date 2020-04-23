using System;
using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class BankAccount: BaseEntity{
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public decimal MaintenanceFee { get; set; }
        public decimal InterestRate { get; set; }
        public decimal InitialDeposit { get; set; }
        public DateTime DateCreated { get; protected set; } = DateTime.Now;
        public DateTime? LastDeposit { get;  set; }
        public int? Period { get; set; }


        public int AccountStatusId { get; set; }
        public BankAccountStatus AccountStatus { get; set; }

        public int AccountTypeId { get; set; }
        public BankAccountType AccountType { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Transaction> SenderTransactions { get; set; }
        public ICollection<Transaction> ReceiverTransactions { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
