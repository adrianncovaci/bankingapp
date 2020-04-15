using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Domain.EFMapping {
    public class LoanRequestStatusConfiguration: IEntityTypeConfiguration<LoanRequestStatus> {
        public void Configure(EntityTypeBuilder<LoanRequestStatus> builder) {
            builder.HasData(
                            new LoanRequestStatus() { LoanRequestStatusId = 1, Status = "Pending"},
                            new LoanRequestStatus() { LoanRequestStatusId = 2, Status = "Accepted" },
                            new LoanRequestStatus() { LoanRequestStatusId = 3, Status = "Declined" }
                            );
        }
    }
}
