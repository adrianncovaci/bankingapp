using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankingApp.API.Helpers;
using BankingApp.API.Models.Loans;
using BankingApp.API.Repositories.Interfaces;
using BankingApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers {
    [AuthorizeAttribute]
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class LoanController: ControllerBase {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _customerManager;

        public LoanController(IRepository repo, IMapper map, UserManager<User> custom) {
            _repo = repo;
            _mapper = map;
            _customerManager = custom;
        }

        [HttpPostAttribute("request/")]
        public async Task<IActionResult> RequestLoan([FromBody]LoanRequestModel model) {
            var userId = Int32.Parse(User.Identity.Name);
            var customer = await _repo.GetWithWhere<Customer>(o => o.UserId == userId);
            model.CustomerId = customer.Id;
            var loanRequest = _mapper.Map<LoanRequest>(model);
            loanRequest.Status = LoanRequestStatus.Pending;
            await _repo.Add(loanRequest);
            return Ok(loanRequest);
        }

        [HttpGetAttribute("requests/")]
        public async Task<IActionResult> GetLoanRequestsByCurrentUser() {
            var userId = Int32.Parse(User.Identity.Name);
            var customer = await _repo.GetWithWhere<Customer>(o => o.UserId == userId);
            var loanRequests = await _repo.GetWithWhereList<LoanRequest>(o => o.CustomerId == customer.Id);
            var models = _mapper.Map<IList<LoanRequestModel>>(loanRequests);

            

            // foreach(var model in models) {
            //     model.CustomerName = $"{customer.FirstName} {customer.FirstName}";
            // }

            return Ok(models); 
        }

        [AuthorizeAttribute(Policy = "LoanOfficerRole")]
        [HttpPostAttribute("reject/{id}")]
        public async Task<IActionResult> DeclineLoanRequest(int id) {
            var loanRequest = await _repo.GetById<LoanRequest>(id);

            if (loanRequest.Status != LoanRequestStatus.Pending) {
                throw new AppException("Bank Account already evaluated");
            }

            loanRequest.Status = LoanRequestStatus.Declined;
            var requestAction = await EvaluateLoanRequest(id, ActionType.Reject);
            await _repo.Add(requestAction);
            return Ok(requestAction);
        }

        [HttpPostAttribute("accept/{id}")]
        public async Task<IActionResult> AcceptLoanRequest(int id) {
            var loanRequest = await _repo.GetById<LoanRequest>(id);

            if (loanRequest.Status != LoanRequestStatus.Pending) {
                throw new AppException("Bank Account already evaluated");
            }
             
            loanRequest.Status = LoanRequestStatus.Accepted;
            var requestAction = await EvaluateLoanRequest(id, ActionType.Accept);
            await _repo.Add(requestAction);
            return Ok(requestAction);
        }

        public async Task<LoanRequestAction> EvaluateLoanRequest(int id, ActionType action) {
            var userId = await Task.FromResult<int>(Int32.Parse(User.Identity.Name));
            var officer = await _repo.GetWithWhere<LoanOfficer>(o => o.UserId == userId);
            var model = new EvaluateLoanRequestModel() {
                LoanOfficerId = officer.Id,
                LoanRequestId = id,
                Action = action
            };
            var requestAction = _mapper.Map<LoanRequestAction>(model);
            return requestAction;
        }

        [HttpGetAttribute("loans")]
        public async Task<IActionResult> GetLoans() {
            var loans = await _repo.GetAll<Loan>();
            var models = _mapper.Map<IList<LoanModel>>(loans);
            var types = await _repo.GetAll<LoanType>();
            foreach(var model in models) {
                foreach(var type in types)
                    if (model.LoanTypeId == type.Id) {
                        model.Type = type.Type;
                        break;
                    }
            }
            return Ok(models);
        }


    }
}
