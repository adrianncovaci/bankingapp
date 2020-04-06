using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CustomerConfiguration: IEntityTypeConfiguration<Customer> {
    public void Configure(EntityTypeBuilder<Customer> builder) {
        builder.ToTable("Customers");

        builder.HasMany(o => o.Accounts)
            .WithOne(o => o.Customer);

        builder.HasIndex(o => o.CNP).IsUnique();
        builder.HasIndex(o => o.Email).IsUnique();

        builder.Property(o => o.CNP).HasMaxLength(13);

        builder.Property(o => o.FirstName).HasMaxLength(32).IsRequired();
        builder.Property(o => o.LastName).HasMaxLength(32).IsRequired();

        builder.Property(o => o.CreditScore).HasDefaultValue(540).IsRequired();

        builder.Property(o => o.State).IsRequired();

        builder.Property(o => o.ZipCode).HasMaxLength(6).IsRequired();
    }
}
