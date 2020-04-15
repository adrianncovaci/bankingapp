using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Domain.EFMapping {
    public class LoanTypeConfiguration: IEntityTypeConfiguration<LoanType> {
        public void Configure(EntityTypeBuilder<LoanType> builder) {
            builder.Property(o => o.Type)
                .HasMaxLength(128)
                .IsRequired();
        }
    }
}
