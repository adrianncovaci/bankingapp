using System;

namespace BankingApp.Domain.Entities {
    public class Transaction {
        public int TransactionId { get; set; }
        public DateTime DateIssued { get; private set; } = DateTime.Now;
        public decimal Amount { get; set; }

        public int SenderAccountId { get; set; }
        public Account SenderAccount { get; set; }
        public int ReceiverAccountId { get; set; }
        public Account ReceiverAccount { get; set; }
    }
}
