using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Account
    {
        public int AccountId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string UrlPicture { get; set; }
        public Link Link { get; set; }
        public int LinkId { get; set; }
    }
}
