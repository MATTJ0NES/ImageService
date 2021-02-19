using ImageService.Attributes;
using ImageService.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ImageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiKey]
    public class ImageController : Controller
    {
        public static IHostingEnvironment _environment;
        IConfiguration _iconfiguration;
        public ImageController(IHostingEnvironment environment, IConfiguration iconfiguration)
        {
            _environment = environment;
            _iconfiguration = iconfiguration;
        }
        public class FIleUploadAPI
        {
            public IFormFile files { get; set; }
        }

        //
        // Summary:
        // Accepts a jpeg file with a numerical filename e.g. 1234.jpg and saves in a directory structure based on this numerical file Id. 
        [HttpPost("UploadImage")]
        public async Task<string> UploadImage(IFormFile files)
        {
            if (files.Length < 0)
            {
                return "Unsuccessful";
            }

            try { 
                string fileName = files.FileName;
                
                int fileID = Int32.Parse(Path.GetFileNameWithoutExtension(files.FileName));

                string path = UrlHelpers.GetFileStoragePath(fileID, fileName, '\\');

                path = Path.Combine(_environment.WebRootPath, _iconfiguration["ImageStore"] + "\\", path);

                if (!Directory.Exists(path.Replace(fileName, "")))
                {
                    Directory.CreateDirectory(path.Replace(fileName, ""));
                }

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(stream);
                }

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
