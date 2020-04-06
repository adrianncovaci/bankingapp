using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Data {
    public class AccountStatusConfiguration: IEntityTypeConfiguration<AccountStatus> {
        public void Configure(EntityTypeBuilder<AccountStatus> builder) {
            builder.HasData(
                            new AccountStatus() { AccountStatusId = 1, Status = "Active" },
                            new AccountStatus() { AccountStatusId = 2, Status = "Frozen" }
                            );
        }
    }
}
