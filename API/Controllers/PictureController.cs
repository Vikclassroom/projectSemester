using API.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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

        [HttpPost]
        public async Task<string> HandleImg([FromForm] FileUpload objFile)
        {
            try
            {
                if (objFile.Files.Length > 0)
                {
                    string path = _environment.WebRootPath + "\\Assets\\img\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using FileStream fileStream = System.IO.File.Create(path + objFile.Files.FileName);
                    await objFile.Files.CopyToAsync(fileStream);
                    fileStream.Flush();
                    return path + objFile.Files.FileName;
                }
                else
                {
                    return "Aucune image sélectionné";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}
