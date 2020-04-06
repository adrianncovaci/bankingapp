using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LoanRequestConfiguration: IEntityTypeConfiguration<LoanRequest> {
    public void Configure(EntityTypeBuilder<LoanRequest> builder) {
        builder.Property(o => o.ResponseDate)
            .ValueGeneratedOnUpdate();

        builder.HasOne(o => o.LoanRequestStatus)
            .WithMany(o => o.LoanRequests)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.LoanOfficer)
            .WithMany(o => o.LoanRequests)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Loan)
            .WithMany(o => o.LoanRequests)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(o => o.Account)
            .WithMany(o => o.LoanRequests)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
