using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class AccountStatus {
        public int AccountStatusId { get; set; }
        public string Status { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
