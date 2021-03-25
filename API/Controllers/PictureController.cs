using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : Controller
    {
        private static IWebHostEnvironment _environment;
        public PictureController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public class FileUpload
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<string> HandleImg(FileUpload objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Assets\\Img\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Assets\\Img\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Assets\\Img\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Assets\\Img\\" + objFile.files.FileName;
                    }
                }
                else
                {
                    return "Échec";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
