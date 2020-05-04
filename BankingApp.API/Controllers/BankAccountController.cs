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
using BankingApp.API.Helpers;
using BankingApp.API.Models.Transactions;
using System.Linq;

namespace BankingApp.API.Controllers {
    [AuthorizeAttribute]
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class BankAccountController: ControllerBase {

        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _serv;
        private readonly IBankAccountRepository _bankRepo;

        public BankAccountController(IRepository repo, IBankAccountRepository bankRepo,
                                     IMapper mapper, ITransactionRepository serv) {
            _repo = repo;
            _mapper = mapper;
            _serv = serv;
            _bankRepo = bankRepo;
        }

        [Authorize(Roles = "Admin")]
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

        [HttpGetAttribute]
        public async Task<IActionResult> GetBankAccountsByUser() {
            var userId = Int32.Parse(User.Identity.Name);
            var customers = await _repo.GetWithWhere<Customer>(x => x.UserId == userId); 
            var customer = customers.FirstOrDefault();
            var bankAccs = await _repo.GetWithWhere<BankAccount>(x => x.CustomerId == customer.Id);
            var models = _mapper.Map<IList<BankAccountModel>>(bankAccs);
            return Ok(bankAccs);
        }

        [HttpGetAttribute("types")]
        public async Task<IActionResult> GetBankAccountTypes() {
            var types = await _repo.GetAll<BankAccountType>();
            return Ok(types);
        }

        [HttpPostAttribute]
        public async Task<IActionResult> CreateAccount(CreateBankAccountModel model) {

            var customerId = User.Identity.Name;
            var bankAccount = await _bankRepo.CreateAccount(model,  customerId);
            var bankModel = _mapper.Map<BankAccountModel>(bankAccount);

            await _repo.Add(bankAccount);
            return Ok(bankAccount);
        }

        [HttpPostAttribute("freeze/{id}")]
        public async Task<IActionResult> FreezeBankAccount(int id) {
            var account = await _repo.GetById<BankAccount>(id);
            if (account == null)
                throw new AppException("Account not available.");
            if (string.Equals(account.BankAccountStatus.ToString(), "frozen", StringComparison.InvariantCultureIgnoreCase))
                throw new AppException("Account is already frozen.");

            account.BankAccountStatus = BankAccountStatus.Frozen;

            await _repo.SaveAll();

            return Ok();
        }

        [HttpPostAttribute("activate/{id}")]
        public async Task<IActionResult> ActivateBankAccount(int id) {
            var account = await _repo.GetById<BankAccount>(id);
            if (account == null)
                throw new AppException("Account not available.");
            if (string.Equals(account.BankAccountStatus.ToString(), "active", StringComparison.InvariantCultureIgnoreCase))
                throw new AppException("Account is already active.");

            account.BankAccountStatus = BankAccountStatus.Active;

            await _repo.SaveAll();

            return Ok();
        }

        [HttpPostAttribute("deposit/")]
        public async Task<IActionResult> Deposit([FromBodyAttribute]DepositWithdrawalModel model) {
            var transactionModel = await _serv.Deposit(model);
            transactionModel.TransactionType = Enum.GetName(typeof(TransactionType), TransactionType.Deposit);
            var transaction = await _serv.CreateTransaction(transactionModel);
            return Ok();
        }

        [HttpPostAttribute("withdraw/")]
        public async Task<IActionResult> Withdraw([FromBodyAttribute]DepositWithdrawalModel model) {
            var transactionModel = await _serv.Withdraw(model);
            transactionModel.TransactionType = Enum.GetName(typeof(TransactionType), TransactionType.Withdrawal);
            var transaction = await _serv.CreateTransaction(transactionModel);
            return Ok();
        }

        [HttpPostAttribute("transfer/")]
        public async Task<IActionResult> Transfer([FromBodyAttribute]TransactionModel model) {
            var receiverList = await _repo.GetWithWhere<BankAccount>(o => o.AccountNumber == model.ReceiverAccountName);
            var receiver = receiverList.FirstOrDefault();
            model.ReceiverAccountId = receiver.Id;
            await _serv.Transfer(model);
            model.TransactionType = Enum.GetName(typeof(TransactionType), TransactionType.Transfer);
            var transaction = await _serv.CreateTransaction(model);
            return Ok(model);
        }
    }
}
