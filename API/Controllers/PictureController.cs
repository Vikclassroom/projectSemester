using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Hosting;
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
        private readonly Context _context;

        private static IWebHostEnvironment _environment;
        public PictureController(IWebHostEnvironment environment, Context context)
        {
            _environment = environment;
            _context = context;
        }

        [HttpPost("upload/{idCurrentAccount}")]
        public async Task<string> HandleImg([FromForm] FileUpload objFile, int idCurrentAccount)
        {
            try
            {
                
                var file = new FileUpload();

                if (objFile.Files == null)
                {
                    file.Files = Request.Form.Files[0];
                }
                else
                {
                    file = objFile;
                }

                if (file.Files != null)
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

                    var fileName = file.Files.FileName.ToString();
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
                    await file.Files.CopyToAsync(fileStream);
                    fileStream.Flush();

                    currentAccount.UrlPicture = newName;
                    _context.Update(currentAccount);
                    await _context.SaveChangesAsync();

                    return newName;
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

        [HttpGet("download/{idAccount}")]
        public async Task<string> GetImg(int idAccount) 
        {
            var account = await _context.Accounts.FindAsync(idAccount);
            return account.UrlPicture;
        }
    }
}
