using Microsoft.AspNetCore.Identity;

namespace API.Identity
{
    public class AppAccount : IdentityUser
    {
        public string DisplayEmail { get; set; }
    }
}
