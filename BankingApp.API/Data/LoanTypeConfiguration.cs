using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LoanTypeConfiguration: IEntityTypeConfiguration<LoanType> {
    public void Configure(EntityTypeBuilder<LoanType> builder) {
        builder.Property(o => o.Type)
            .HasMaxLength(128)
            .IsRequired();
    }
}
