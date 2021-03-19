using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UrlPicture { get; set; }
    }
}
