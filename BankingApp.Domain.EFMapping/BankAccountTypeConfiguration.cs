using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Data {
    public class AccountTypeConfiguration: IEntityTypeConfiguration<BankAccountType> {
        public void Configure(EntityTypeBuilder<BankAccountType> builder) {
            builder.ToTable("BankAccountTypes");

            builder.Property(o => o.Type)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(o => o.Code)
                .HasMaxLength(3)
                .IsRequired();

            builder.Property(o => o.InitialInterestRate)
                .IsRequired();

            builder.Property(o => o.MaintenanceFee)
                .IsRequired();

            builder.HasData(
                            new BankAccountType() { Id = 1, Type = "Savings", Code = "101", InitialInterestRate = 0.03m, MaintenanceFee = 10m },
                            new BankAccountType() { Id = 2, Type = "Checkings", Code = "301", InitialInterestRate = 0m, MaintenanceFee = 10m },
                            new BankAccountType() { Id = 3, Type = "Retirement", Code = "901", InitialInterestRate = 0.04m, MaintenanceFee = 0m}
                            );
        }
    }
}
