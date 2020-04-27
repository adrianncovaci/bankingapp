using AutoMapper;
using BankingApp.API.Models.Loans;
using BankingApp.Domain.Entities;

namespace BankingApp.API.Profiles {
    public class LoanProfile: Profile {
        public LoanProfile() {
            CreateMap<LoanRequest, LoanRequestModel>()
                .ForMember(x => x.CustomerId , y => y.MapFrom(z => z.Customer.Id));
            CreateMap<LoanRequestModel, LoanRequest>();
            CreateMap<LoanRequestAction, EvaluateLoanRequestModel>();
            CreateMap<EvaluateLoanRequestModel, LoanRequestAction>();
        }
    }
}
