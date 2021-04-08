using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PictureController : Controller
    {
        private readonly Context _context;

        private static IWebHostEnvironment _environment;
        public PictureController(IWebHostEnvironment environment, Context context)
        {
            _environment = environment;
            _context = context;
        }

       /* [HttpGet("download")]
        public async Task<string> GetImg()$*/

        [HttpPost("upload")]
        public async Task<string> HandleImg([FromForm] FileUpload objFile, int idCurrentAccount)
        {
            try
            {
                if (objFile.Files.Length > 0)
                {
                    var currentAccount = await _context.Accounts.FindAsync(idCurrentAccount);
                    var lastUrlPicture = currentAccount.UrlPicture;
                    string path = _environment.WebRootPath + "\\Assets\\img\\";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (lastUrlPicture != "placeholder.png")
                    {
                        System.IO.File.Delete(path + lastUrlPicture);
                    }

                    var fileName = objFile.Files.FileName.ToString();
                    var explode = fileName.Split('.');
                    var extension = explode.Last();
                    var fileNameWithoutExtension = String.Join('.',explode.Take(explode.Count() - 1).ToArray());
                    var newName = fileNameWithoutExtension + '.' + extension;

                    var n = 0;
                    while (System.IO.File.Exists(path + newName))
                    {
                        n++;
                        newName = fileNameWithoutExtension + '(' + n + ')' + '.' + extension;
                    }

                    using FileStream fileStream = System.IO.File.Create(path + newName);
                    await objFile.Files.CopyToAsync(fileStream);
                    fileStream.Flush();

                    currentAccount.UrlPicture = newName;
                    _context.Update(currentAccount);
                    await _context.SaveChangesAsync();

                    return path + newName;
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
