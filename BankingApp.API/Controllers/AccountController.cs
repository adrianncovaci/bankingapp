using System;
using Microsoft.EntityFrameworkCore;
using BankingApp.Domain.EFMapping;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankingApp.API.Controllers {
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class AccountController: ControllerBase {

        private readonly BankContext _context;

        public AccountController(BankContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts() {
            var accounts = await _context.Accounts.ToListAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccounts(int id) {
            var account = await _context.Accounts.FirstOrDefaultAsync(o => o.AccountId == id);
            return Ok(account);
        }
    }
}
