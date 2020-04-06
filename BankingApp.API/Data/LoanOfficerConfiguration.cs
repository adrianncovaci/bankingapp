using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Data {
    public class LoanOfficerConfiguration: IEntityTypeConfiguration<LoanOfficer> {
        public void Configure(EntityTypeBuilder<LoanOfficer> builder) {
            builder.ToTable("LoanOfficers");

            builder.HasIndex(o => o.EmailAddress).IsUnique();
            builder.HasIndex(o => o.PhoneNumber).IsUnique();

            builder.Property(o => o.FirstName)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(o => o.LastName)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
