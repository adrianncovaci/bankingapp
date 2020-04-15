using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;

using BankingApp.API.Helpers;
using BankingApp.API.Models;
using BankingApp.Domain.Entities;
using BankingApp.Domain.EFMapping;
using Microsoft.AspNetCore.Identity;

namespace BankingApp.API.Controllers {
    [AuthorizeAttribute]
    [ApiControllerAttribute]
    [Route("[controller]")]
    public class CustomerController: ControllerBase {
        private readonly AppSettings _settings;
        private UserManager<Customer> _customerManager;
        private IMapper _mapper;
        private readonly BankContext _context;

        public CustomerController(BankContext context, IMapper mapper,
                                  IOptions<AppSettings> appSettings, UserManager<Customer> manager) {
            _mapper = mapper;
            _settings = appSettings.Value;
            _context = context;
            _customerManager = manager;
        }

        [AllowAnonymousAttribute]
        [HttpPostAttribute("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model) {
            var customer = await _customerManager.FindByEmailAsync(model.Email);

            if (customer == null || !await _customerManager.CheckPasswordAsync(customer, model.Password))
                return BadRequest(new { message = "Incorrect email and/or password" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, customer.Id.ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok( new {
                    Token = tokenString
                } );
        }

        [AllowAnonymousAttribute]
        [HttpPostAttribute("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model) {
            var customer = _mapper.Map<Customer>(model);
            customer.UserName = customer.Email;
            try {
                var result = await _customerManager.CreateAsync(customer, model.Password);
                return Ok(result);
            }
            catch(AppException e) {
                return BadRequest( new { message = e.Message } );
            }
        }

        [HttpGetAttribute]
        public async Task<IActionResult> GetAll() {
            var customers = await _context.Customers.ToListAsync();
            var models = _mapper.Map<IList<CustomerModel>>(customers);

            return Ok(customers);
        }

        [HttpGetAttribute("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var customer = await _context.Customers.FindAsync(id);
            var model = _mapper.Map<CustomerModel>(customer);
            return Ok(model);
        }

        [HttpPutAttribute("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]UpdateModel model) {
            var cust = _mapper.Map<Customer>(model);
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
                throw new AppException("User not found!");

            if (!string.IsNullOrEmpty(cust.Email) && cust.Email != customer.Email ) {

                if (await _context.Customers.AnyAsync(x => x.Email == cust.Email))
                    throw new AppException("Email is already taken");

                customer.Email = cust.Email;
            }

            if (!string.IsNullOrWhiteSpace(cust.FirstName))
                customer.FirstName = cust.FirstName;

            if (!string.IsNullOrWhiteSpace(cust.LastName))
                customer.LastName = cust.LastName;

            if (!string.IsNullOrWhiteSpace(cust.City))
                customer.City = cust.City;

            if (!string.IsNullOrWhiteSpace(cust.Address))
                customer.Address = cust.Address;

            if (!string.IsNullOrWhiteSpace(cust.ZipCode))
                customer.ZipCode = cust.ZipCode;

            await _customerManager.UpdateAsync(customer);
            return Ok();
        }


        [HttpDeleteAttribute("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var cust = await _context.Customers.FindAsync(id);
            await _customerManager.DeleteAsync(cust);
            return Ok();
        }
    }
}
