using System.Collections.Generic;

namespace BankingApp.API.Models {
    public class AccountType {
        public int AccountTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
