using System.ComponentModel.DataAnnotations;

namespace TaskAPI.DTOs.Request
{
    public class RegisterRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}
