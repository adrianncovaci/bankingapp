using System;
using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.Domain.EFMapping {
    public class AccountConfiguration: IEntityTypeConfiguration<Account> {
        public void Configure(EntityTypeBuilder<Account> builder) {
            builder.ToTable("Accounts");
            builder.HasIndex(o => o.AccountNumber).IsUnique();

            builder.Property(o => o.AccountNumber)
                .HasMaxLength(13)
                .IsRequired();

            builder.Property(o => o.LastDeposit).ValueGeneratedOnAddOrUpdate();

            builder.HasOne(o => o.AccountType)
                .WithMany(o => o.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.Customer)
                .WithMany(o => o.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.AccountStatus)
                .WithMany(o => o.Accounts)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(o => o.InitialDeposit)
                .IsRequired();

            builder.Property(o => o.DateCreated)
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

        }
    }
}
