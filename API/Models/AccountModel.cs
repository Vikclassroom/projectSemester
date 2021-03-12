using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AccountModel
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UrlPicture { get; set; }
        
    }
}
