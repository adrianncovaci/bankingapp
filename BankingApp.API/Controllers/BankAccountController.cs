using System;
using Microsoft.EntityFrameworkCore;
using BankingApp.Domain.EFMapping;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;

using BankingApp.Domain.Entities;
using BankingApp.API.Models.BankAccounts;
using BankingApp.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BankingApp.API.Helpers.BankAccount;

namespace BankingApp.API.Controllers {
    [AuthorizeAttribute]
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class BankAccountController: ControllerBase {

        private readonly IRepository _repo;
        private readonly UserManager<Customer> _customerManager;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _tRepo;

        public BankAccountController(IRepository repo, UserManager<Customer> customerManager, IMapper mapper) {
            _repo = repo;
            _customerManager = customerManager;
            _mapper = mapper;
        }

        [HttpGetAttribute("all")]
        public async Task<IActionResult> GetAccounts() {
            var accs = await _repo.GetAll<BankAccount>();
            var models = _mapper.Map<IList<BankAccountModel>>(accs);
            return Ok(models);
        }

        [HttpGetAttribute("{id}")]
        public async Task<IActionResult> GetAccountById(int id) {
            var account = await _repo.GetById<BankAccount>(id);
            var model = _mapper.Map<BankAccountModel>(account);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetBankAccountsByUser() {
            var customerId = Int32.Parse(User.Identity.Name);
            var bankAccs = await _repo.GetWithWhere<BankAccount>(x => x.CustomerId == customerId);
            var models = _mapper.Map<IList<BankAccountModel>>(bankAccs);
            return Ok(bankAccs);
        }

        [HttpPostAttribute]
        public async Task<IActionResult> CreateAccount(CreateBankAccountModel model) {
            var customerId = User.Identity.Name;
            var customer = await _customerManager.FindByIdAsync(customerId);
            var bankAccountType = await _repo.GetById<BankAccountType>(model.AccountType);
            if (customer == null || bankAccountType == null)
                return BadRequest(customer.Id);
           
            var bankAccountName = await CreateBankAccount.GenerateBankAccountNumber(bankAccountType.Code, customer);
            var balance = model.InitialDeposit;
            var initialDeposit = model.InitialDeposit;
            var maintenanceFee = bankAccountType.MaintenanceFee;
            var interestRate = bankAccountType.InitialInterestRate;
            DateTime? lastDeposit;
            if(initialDeposit > 0) {
                lastDeposit = DateTime.Now;
            } else {
                lastDeposit = null;
            }
            var accountStatus = await _repo.GetById<BankAccountStatus>(1);

            var bankAccount = new BankAccount {
                AccountNumber = bankAccountName,
                Balance = balance,
                MaintenanceFee = maintenanceFee,
                InterestRate = interestRate,
                InitialDeposit = initialDeposit,
                LastDeposit = lastDeposit,
                AccountStatus = accountStatus,
                AccountType = bankAccountType,
                Customer = customer
            };

            var bankModel = _mapper.Map<BankAccountModel>(bankAccount);
            bankModel.AccountStatus = accountStatus.Status;

            await _repo.Add(bankAccount);
            return Ok(bankModel);
        }
    }
}
