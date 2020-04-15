using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Domain.EFMapping {
    public class LoanConfiguration: IEntityTypeConfiguration<Loan> {
        public void Configure(EntityTypeBuilder<Loan> builder) {
            builder.HasOne(o => o.LoanType)
                .WithMany(o => o.Loans)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
