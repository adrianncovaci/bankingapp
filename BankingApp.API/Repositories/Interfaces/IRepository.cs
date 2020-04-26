using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using BankingApp.Domain.Entities;
using System.Linq.Expressions;

namespace BankingApp.API.Repositories.Interfaces {
    public interface IRepository {
        Task<T> GetById<T>(int id) where T: BaseEntity;
        Task<List<T>> GetAll<T>() where T: BaseEntity;
        Task<List<T>> GetWithWhere<T>(params Expression<Func<T, bool>>[] props) where T: BaseEntity;
        Task<T> Add<T>(T entity) where T: BaseEntity;
        Task<T> Update<T> (T entity) where T: BaseEntity;
        Task<T> Delete<T> (int id) where T: BaseEntity;
        Task<bool> SaveAll();
    }
}
