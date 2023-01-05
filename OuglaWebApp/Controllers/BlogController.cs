using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;
using System.IO;
using System.IO.Compression;
using static System.Net.Mime.MediaTypeNames;

namespace OuglaWebApp.Controllers
{
    public class BlogController : Controller
    {
        BlogHandling blog=new BlogHandling();
        public static string siteName;
        public IActionResult BlogEditor()
        {
            if (TempData.ContainsKey("siteName"))
                siteName = TempData["siteName"] as string;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadBlog(BlogModel blogModel, IFormFile file)
        {
            try
            {
                using (var target = new MemoryStream())
                {
                    await file.CopyToAsync(target);
                    blogModel.Image = target.ToArray();
                }
                blog.UploadBlog(blogModel, siteName);
                return View();
            }
            catch (Exception)
            {
                TempData["msg"] = "<script>alert('Oops! Something went wrong');</script>";
                return View();
            }
            //var files = Request.Form.Files;

        }

        [HttpPost]
       public async Task<IActionResult> getfile(IFormFile Image)
        {
            using (var target = new MemoryStream())
            {
                await Image.CopyToAsync(target);

                // Upload the file if less than 2 MB
                if (target.Length < 2097152)
                {
                    var img = new BlogModel()
                    {
                        Image = target.ToArray()
                    };
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
            return View();
        }
    }
}
