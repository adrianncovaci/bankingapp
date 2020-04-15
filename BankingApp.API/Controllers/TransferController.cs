using System;
using BankingApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BankingApp.Domain.EFMapping;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BankingApp.API.Controllers {
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class TransferController: ControllerBase {

        private readonly BankContext _context;

        public TransferController(BankContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions() {
            var transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id) {
            var value = await _context.Transactions.FirstOrDefaultAsync(t => t.TransactionId == id);
            return Ok(value);
        }

        // [HttpPutAttribute]
        // [Route("[controller]/{}")]
        // public async Task<IActionResult> TransferToPeer(Account send, Account rcv, int amount) {
        //     using (var transaction = await _context.Database.BeginTransactionAsync()) {
        //         try {
        //             Console.WriteLine("ADSASD");
        //             if (send.Balance >= amount) {
        //                 send.Balance -= amount;
        //                 rcv.Balance += amount;
        //             } else {
        //                 return new NoContentResult();
        //             }
        //             Console.WriteLine("ADSASD");
        //             transaction.Commit();
        //         }
        //         catch (Exception) {
        //         }
        //     }

        //     return Ok();
        // }

    }
}
