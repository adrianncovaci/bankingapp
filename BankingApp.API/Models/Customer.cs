using System;
using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class Customer {
        public int CustomerId { get; set; }
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short CreditScore { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public DateTime RegisteredDate { get; private set; } = DateTime.Now;

        public DateTime DateHired { get; private set; } = DateTime.Now;

        public ICollection<Account> Accounts { get; set; }
    }
}
