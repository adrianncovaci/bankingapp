using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BankingApp.Domain.Entities;

namespace BankingApp.API.Repositories.Interfaces {
    public interface ITransactionRepository {
        // Task<T> GetByUser<T>(int id) where T: BaseEntity;
        Task<T> Withdraw<T>(int accId, decimal amount) where T: BaseEntity;
        Task<T> Deposit<T> (int accId, decimal amount) where T: BaseEntity;
    }
}
