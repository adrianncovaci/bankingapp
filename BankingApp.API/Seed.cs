using System.Collections.Generic;
using System.Threading.Tasks;
using BankingApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankingApp.API {
    public class Seed {

        public static async Task SeedUsers(UserManager<Customer> _customerManager) {
            var email = "admin@banca.com";
            if (await _customerManager.FindByEmailAsync(email) == null) {
                var password = "iamr00t";
                var admin = new Customer {
                    Email = email,
                    UserName = email,
                    FirstName = "admin",
                    LastName = "admin",
                    CNP = "xxx",
                    City = "Gotham",
                    Address = "mars",
                    ZipCode = "None"

                };
                var result = await _customerManager.CreateAsync(admin, password);
                if (result.Succeeded) {
                    var administrator = await _customerManager.FindByEmailAsync(email);
                    await _customerManager.AddToRoleAsync(administrator, "Admin");
                }
            }

        }

        public static async Task SeedRoles(RoleManager<Role> roleManager) {
            if ( !await roleManager.RoleExistsAsync("Admin")) {
                var roles = new List<Role>
                {
                    new Role { Name = "Admin" },
                    new Role { Name = "Customer" },
                    new Role { Name = "LoanOfficer" }
                };

                foreach (var role in roles) {
                    await roleManager.CreateAsync(role);
                }
            }
        }
    }
}
