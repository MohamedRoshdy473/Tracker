using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackingSystemAPI.Models;

namespace TrackingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadImageController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost]
        [Route("imageupload")]
        public async Task<IActionResult> index(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
                return Content("file not selected");
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images");

                    filePaths.Add(filePath);

                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePaths });
        }












    }
}
