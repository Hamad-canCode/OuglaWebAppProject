using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.Models;
using System.Reflection.Metadata;

namespace OuglaWebApp.Controllers
{
    public class EditorController : Controller
    {

        public IActionResult Editor()
        {
            return View();
        }

      
    }
}
