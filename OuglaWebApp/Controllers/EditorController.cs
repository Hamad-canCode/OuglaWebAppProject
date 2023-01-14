using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.Models;

namespace OuglaWebApp.Controllers
{
    public class EditorController : Controller
    {

        public IActionResult Editor()
        {
            return View();
        }

        [HttpPost]
        public void EditorContent(Content content, IFormFile logo,IFormFile Banner, IFormFile objImg)
        {
    
        }

    }
}
