using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankingApp.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Controllers
{
    [Route("[controller]")]
    // [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly BankContext _context;

        public WeatherForecastController(BankContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTypes() {
            var values = await _context.AccountTypes.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetType(int id) {
            var value = await _context.AccountTypes.FirstOrDefaultAsync(x => x.AccountTypeId == id);
            return Ok(value);
        }

    }
}
