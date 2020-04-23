using AutoMapper;
using BankingApp.API.Models.BankAccounts;
using BankingApp.Domain.Entities;

namespace BankingApp.API.Profiles {
    public class BankAccountProfile: Profile {
        public BankAccountProfile() {
            CreateMap<BankAccount, BankAccountModel>()
                .ForMember(x => x.AccountStatus, y => y.MapFrom(z => z.AccountStatus.Status.ToUpper()));
            CreateMap<BankAccount, BankAccountModel>()
                .ForMember(x => x.AccountType, y => y.MapFrom(z => z.AccountType.Type));
            CreateMap<BankAccountModel, BankAccount>();
        }
    }
}
