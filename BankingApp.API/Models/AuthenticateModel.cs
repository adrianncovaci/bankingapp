using System.ComponentModel.DataAnnotations;

namespace BankingApp.API.Models {
    public class AuthenticateModel {
        [RequiredAttribute]
        public string Email { get; set; }
        [RequiredAttribute]
        public string Password { get; set; }
    }
}
