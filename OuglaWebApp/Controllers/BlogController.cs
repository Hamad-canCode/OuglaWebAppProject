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
        BlogHandling blog = new BlogHandling();
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
                if (file!=null)
                {
                    using (var target = new MemoryStream())
                    {
                        await file.CopyToAsync(target);
                        blogModel.Image = target.ToArray();
                    }
                    blog.UploadBlog(blogModel, siteName);
                    TempData["msg"] = "<script>alert('Your Blog has been Published!!!');</script>";
                    return RedirectToAction("BlogEditor", "Blog");
                }
                else
                {
                    blog.UploadBlog(blogModel, siteName);
                    TempData["msg"] = "<script>alert('Your Blog has been Published!!!');</script>";
                    return RedirectToAction("BlogEditor", "Blog");
                }
            }
            catch (Exception)
            {
                TempData["msg"] = "<script>alert('Oops! Something went wrong');</script>";
                return RedirectToAction("BlogEditor", "Blog");
            }
            
        }
        public IActionResult SiteEditor()
        {
            if (TempData.ContainsKey("siteName"))
                siteName = TempData["siteName"] as string;

            return View();
        }

    }
}

