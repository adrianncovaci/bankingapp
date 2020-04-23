using System.Threading.Tasks;
using AutoMapper;
using BankingApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankingApp.API.Repositories {
    public class BankAccountRepository {
        private readonly BankContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _customerManager;

        public BankAccountRepository(BankContext context, IMapper mapper, UserManager<Customer> customerManager) {
            _context = context;
            _mapper = mapper;
            _customerManager = customerManager;
        }

        // [HttpPostAttribute]
        // public async Task<IActionResult> Withdrawal(int amount) {
        //     Customer customer = await _customerManager.GetUserAsync(User);
        // }
    }
}
