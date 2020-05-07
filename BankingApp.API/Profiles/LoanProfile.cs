using AutoMapper;
using BankingApp.API.Models.Customer;
using BankingApp.API.Models.Loans;
using BankingApp.Domain.Entities;

namespace BankingApp.API.Profiles {
    public class LoanProfile: Profile {
        public LoanProfile() {
            CreateMap<LoanRequest, LoanRequestModel>()
                .ForMember(x => x.CustomerName , y => y.MapFrom(z => z.Customer.CNP));

            CreateMap<Loan, LoanModel>();
            CreateMap<LoanModel, Loan>();
            CreateMap<LoanRequestModel, LoanRequest>();
            CreateMap<LoanRequestAction, EvaluateLoanRequestModel>();
            CreateMap<EvaluateLoanRequestModel, LoanRequestAction>();

            CreateMap<LoanOfficer, RegisterModel>();
            CreateMap<RegisterModel, LoanOfficer>();
        }
    }
}
