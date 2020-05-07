using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BankingApp.API.Repositories.Interfaces;
using BankingApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers {
    [AuthorizeAttribute]
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class TransactionController: ControllerBase {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public TransactionController(IRepository repository, IMapper mapper) {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGetAttribute("transactions/{id}")]
        public async Task<IActionResult> GetTransactionsByUser(int id) {
            var acc = await _repo.GetById<BankAccount>(id);
            var transactions = await _repo.GetWithWhereList<Transaction>(o => o.SenderAccountId == acc.Id);
            return Ok(transactions); 
        }
    }
}