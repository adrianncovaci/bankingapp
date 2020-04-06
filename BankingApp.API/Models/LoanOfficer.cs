using System;
using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class LoanOfficer {
        public int LoanOfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateHired { get; private set; } = DateTime.Now;
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<LoanRequest> LoanRequests { get; set; }
    }
}
