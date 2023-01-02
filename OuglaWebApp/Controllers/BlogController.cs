using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.Models;

namespace OuglaWebApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult BlogEditor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadBlog(BlogModel blogModel)
        {
            return View();
        }
    }
}
