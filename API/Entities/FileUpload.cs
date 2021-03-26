using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
