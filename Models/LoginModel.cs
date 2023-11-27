using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LibraryManagement.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = true;
    }
}
