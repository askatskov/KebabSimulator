using System.ComponentModel.DataAnnotations;

namespace Kebab_Simulator.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
