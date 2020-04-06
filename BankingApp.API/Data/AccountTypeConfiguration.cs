using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Data {
    public class AccountTypeConfiguration: IEntityTypeConfiguration<AccountType> {
        public void Configure(EntityTypeBuilder<AccountType> builder) {
            builder.ToTable("AccountTypes");

            builder.HasData(
                            new AccountType() { AccountTypeId = 1, Type = "Savings" },
                            new AccountType() { AccountTypeId = 2, Type = "Checkings" },
                            new AccountType() { AccountTypeId = 3, Type = "Retirement" }
                            );
        }
    }
}
