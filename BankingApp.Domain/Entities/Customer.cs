using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace BankingApp.Domain.Entities {
    public class Customer: IdentityUser<int> {
        public string CNP { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short CreditScore { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public DateTime RegisteredDate { get; private set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
