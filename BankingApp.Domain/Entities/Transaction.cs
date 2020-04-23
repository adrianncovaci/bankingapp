using System;

namespace BankingApp.Domain.Entities {
    public class Transaction: BaseEntity {
        public DateTime DateIssued { get; private set; } = DateTime.Now;
        public decimal Amount { get; set; }

        public int SenderAccountId { get; set; }
        public BankAccount SenderAccount { get; set; }
        public int ReceiverAccountId { get; set; }
        public BankAccount ReceiverAccount { get; set; }
    }
}
