using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;

namespace OuglaWebApp.Controllers
{
    public class SiteDisplayController : Controller
    {

        SiteControll siteControl = null;
        BlogHandling blog = new BlogHandling();
        public static string siteName; 
        public SiteDisplayController(SiteControll siteControle)
        {
            siteControl = siteControle;
        }

        [Route("/{id}")]
        
        public IActionResult HomeBluePrint(string id)
        {
            TempData["verified"] = null;
            TempData["logged"] = null;
            if (siteControl.ValidateSiteName(id))
            {
                siteName = id;
                @ViewData["Site"] = id;
                var dataset = blog.GetBlogData(id);
               
                return View(dataset);
            }
            else
            {
                return View("Error404");
            }
        }

        [Route("/{id}/admin/editor")]
        public IActionResult Editor(string id)
        {
            bool verified = Convert.ToBoolean(TempData["verified"]);
            TempData.Keep("verified");
            string logged="";
            if (TempData["logged"]!=null)
            {
                logged = Convert.ToString(TempData["logged"]);
            }
            
            if ( verified && logged=="true")
            {
                return View("HomeBluePrint");
            }
            else
            {
                return RedirectToAction("Admin", "Admin", new { id = id });
            }
        }

        [Route("/{id}/about")]
        public IActionResult AboutBluePrint(string id)
        {
            id = siteName;
            if (siteControl.ValidateSiteName(id))
            {
                @ViewData["Site"] = id;
                return View();
            }
            else
            {
                return View("Error404");
            }
        }

        public IActionResult displayBlog(int blogid, string title)
        {
            var dataset = blog.Blog(blogid,siteName);
            ViewBag.blogid = blogid;
            return View("/Views/SiteDisplay/Blogblueprint.cshtml",dataset);
        }
        [HttpGet]
        public void getAllBlogs()
        {
            
        }
    }
}
