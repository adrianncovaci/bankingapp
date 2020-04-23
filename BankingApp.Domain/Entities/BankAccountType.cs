using System.Collections.Generic;

namespace BankingApp.Domain.Entities {
    public class BankAccountType: BaseEntity {
        public string Type { get; set; }
        public string Code { get; set; }
        public decimal InitialInterestRate { get; set; }
        public decimal MaintenanceFee { get; set; }

        public ICollection<BankAccount> Accounts { get; set; }
    }
}
