using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class AccountRegisterModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [DisplayName("Phone number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [DisplayName("Re-Type password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password doesnot match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        public int? RoleId { get; set; }


    }
}
