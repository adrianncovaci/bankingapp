using Microsoft.EntityFrameworkCore;
using BankingApp.Domain.Entities;
using BankingApp.Domain.EFMapping;

namespace BankingApp.API {

    public class BankContext: DbContext {
        public BankContext(DbContextOptions<BankContext> options): base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set;}
        public DbSet<AccountType> AccountTypes { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Loan> Loans { get; set;}
        public DbSet<LoanOfficer> LoanOfficers { get; set;}
        public DbSet<LoanRequest> LoanRequests { get; set;}
        public DbSet<LoanRequestStatus> LoanRequestStatuses { get; set;}
        public DbSet<LoanType> LoanTypes { get; set;}
        public DbSet<Transaction> Transactions { get; set;}


        // protected override void OnConfiguring(DbContextOptionsBuilder options);

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var assembly = typeof(CustomerConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
