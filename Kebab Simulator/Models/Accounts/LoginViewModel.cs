using System.ComponentModel.DataAnnotations;

namespace Kebab_Simulator.Models.Accounts
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember this account? ")]
        public bool RememberMe { get; set; }
        public string? ReturnURL { get; set; }
        
    }
}
