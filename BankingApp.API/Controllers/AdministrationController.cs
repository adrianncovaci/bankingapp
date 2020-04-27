using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers {
    public class AdministrationController: ControllerBase {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }

    //     [HttpPostAttribute]
    //     public Task<IActionResult> CreateRole()
    }
}
