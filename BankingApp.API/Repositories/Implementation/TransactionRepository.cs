using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BankingApp.API.Helpers;
using BankingApp.API.Models.Transactions;
using BankingApp.API.Repositories.Interfaces;
using BankingApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Repositories {
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _customerManager;
        private readonly IRepository _repo;

        public TransactionRepository(BankContext context, IMapper mapper, IRepository repo) {
            _context = context;
            _mapper = mapper;
            _repo = repo;
        }

        public async Task _withdraw(int accId, decimal amount)
        {
            if (amount <= 0) {
                throw new AppException("Invalid amount");
            }

            var account = await _repo.GetById<BankAccount>(accId);

            if (account == null) {
                throw new AppException("Unavailable bank account");
            }

            if (account.Balance < amount)
                throw new AppException("Cannot withdraw more than available balance");

            account.Balance -= amount;
        }

        public async Task _deposit(int accId, decimal amount)
        {
            if (amount <= 0) {
                throw new AppException("Invalid amount");
            }
           
            var account = await _repo.GetById<BankAccount>(accId);

            if (account == null) {
                throw new AppException("Unavailable bank account");
            }

            account.Balance += amount;
        }

        public async Task<T> Deposit<T>(int acc, decimal amount) where T : BaseEntity {
            throw new System.NotImplementedException();
        }

        public async Task<T> Withdraw<T>(int accId, decimal amount) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }
    }
}
