using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Data {
    public class TransactionConfigure: IEntityTypeConfiguration<Transaction> {
        public void Configure(EntityTypeBuilder<Transaction> builder) {
            builder.HasOne(o => o.SenderAccount)
                .WithMany(o => o.SenderTransactions)
                .HasForeignKey(o => o.SenderAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(o => o.ReceiverAccount)
                .WithMany(o => o.ReceiverTransactions)
                .HasForeignKey(o => o.ReceiverAccountId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
