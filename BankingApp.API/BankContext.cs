using Microsoft.EntityFrameworkCore;
using BankingApp.Domain.Entities;
using BankingApp.Domain.EFMapping;
using BankingApp.Domain.EFMapping.Schemas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BankingApp.API {

    public class BankContext: IdentityDbContext<Customer, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken> {
        public BankContext(DbContextOptions<BankContext> options): base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankAccountType> BankAccountTypes { get; set;}
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Loan> Loans { get; set;}
        public DbSet<LoanOfficer> LoanOfficers { get; set;}
        public DbSet<LoanRequest> LoanRequests { get; set;}
        public DbSet<LoanRequestAction> LoanRequestActions { get; set; }
        public DbSet<LoanType> LoanTypes { get; set;}
        public DbSet<Transaction> Transactions { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(CustomerConfiguration).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        private void ApplyIdentityMapConfiguration(ModelBuilder builder) {
            builder.Entity<Customer>().ToTable("Customers", SchemaConsts.Auth);
            builder.Entity<UserClaim>().ToTable("UserClaims", SchemaConsts.Auth);
            builder.Entity<UserLogin>().ToTable("UserLogins", SchemaConsts.Auth);
            builder.Entity<UserToken>().ToTable("UserTokens", SchemaConsts.Auth);
            builder.Entity<Role>().ToTable("Roles", SchemaConsts.Auth);
            builder.Entity<RoleClaim>().ToTable("RoleClaims", SchemaConsts.Auth);
            builder.Entity<UserRole>().ToTable("UserRoles", SchemaConsts.Auth);
        }
    }
}
