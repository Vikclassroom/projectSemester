using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("(?= ^.{6, 10}$)(?=.*\\d)(?=.*[a - z])(?=.*[A - Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage = "Le mot de passe doit contenir 1 lettre majuscule, 1 lettre minuscule, 1 nombre, 1 caractère spécial et au moins 6 caractère")]
        public string Password { get; set; }
    }
}
