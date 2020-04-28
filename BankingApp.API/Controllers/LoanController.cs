using System;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly UserManager<Customer> _customerManager;

        public LoanController(IRepository repo, IMapper map, UserManager<Customer> custom) {
            _repo = repo;
            _mapper = map;
            _customerManager = custom;
        }

        [HttpPostAttribute("request/")]
        public async Task<IActionResult> RequestLoan([FromBody]LoanRequestModel model) {
            model.CustomerId = Int32.Parse(User.Identity.Name);
            var loanRequest = _mapper.Map<LoanRequest>(model);
            loanRequest.Status = LoanRequestStatus.Pending;
            await _repo.Add(loanRequest);
            return Ok(loanRequest);
        }

        [AuthorizeAttribute(Policy = "LoanOfficerRole")]
        [HttpPostAttribute("reject/{id}")]
        public async Task<IActionResult> DeclineLoanRequest(int id) {
            var loanRequest = await _repo.GetById<LoanRequest>(id);
            loanRequest.Status = LoanRequestStatus.Accepted;
            var requestAction = await EvaluateLoanRequest(id, ActionType.Accept);
            await _repo.Add(requestAction);
            return Ok(requestAction);
        }


        public async Task<LoanRequestAction> EvaluateLoanRequest(int id, ActionType action) {
            var officerId = await Task.FromResult<int>(Int32.Parse(User.Identity.Name));
            var model = new EvaluateLoanRequestModel() {
                LoanOfficerId = officerId,
                LoanRequestId = id,
                Action = action
            };
            var requestAction = _mapper.Map<LoanRequestAction>(model);
            return requestAction;
        }


    }
}
