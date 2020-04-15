using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class AccountStatus {
        public int AccountStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
