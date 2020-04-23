using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Domain.EFMapping {
    public class AccountStatusConfiguration: IEntityTypeConfiguration<BankAccountStatus> {
        public void Configure(EntityTypeBuilder<BankAccountStatus> builder) {
            builder.HasData(
                            new BankAccountStatus() { Id = 1, Status = "Active" },
                            new BankAccountStatus() { Id = 2, Status = "Frozen" }
                            );
        }
    }
}
