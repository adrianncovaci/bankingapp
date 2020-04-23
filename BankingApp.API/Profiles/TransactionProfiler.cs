using AutoMapper;
using BankingApp.API.Models.Transactions;
using BankingApp.Domain.Entities;

namespace BankingApp.API.Profiles {
    public class TransactionProfile: Profile {
        public TransactionProfile() {
            CreateMap<Transaction, TransactionModel>()
                .ForMember(x => x.ReceiverAccount, y => y.MapFrom(z => z.ReceiverAccount.AccountNumber));
            CreateMap<TransactionModel, Transaction>();
        }
    }
}
