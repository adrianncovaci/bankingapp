using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class BankAccountStatus: BaseEntity {
        public string Status { get; set; }
        public ICollection<BankAccount> Accounts { get; set; }
    }
}
