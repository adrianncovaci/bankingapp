using System;

namespace BankingApp.API.Models.Transactions {
    public class TransactionModel {
        public DateTime DateIssued { get; set; }
        public decimal Amount { get; set; }
        public string ReceiverAccount { get; set; }
        public string ReceiverCustomerName { get; set; }
    }
}
