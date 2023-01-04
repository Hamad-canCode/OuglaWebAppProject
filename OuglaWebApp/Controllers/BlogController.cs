using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;

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
        public IActionResult UploadBlog(BlogModel blogModel)
        {
            blog.UploadBlog(blogModel, siteName);
            return View();
        }
    }
}
