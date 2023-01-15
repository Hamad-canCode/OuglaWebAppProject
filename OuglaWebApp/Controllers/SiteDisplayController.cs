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
        Editor editor = new Editor();
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
            siteName = id;
            bool verified = Convert.ToBoolean(TempData["verified"]);
            TempData.Keep("verified");
            bool logged=false;
            if (TempData["logged"]!=null)
            {
                logged = Convert.ToBoolean(TempData["logged"]);
            }
            
            if ( verified && logged==true)
            {
                return View("HomeBluePrint");
            }
            else
            {
                return RedirectToAction("Admin", "Admin", new { id = id });
            }
        }

        [Route("/{id}/blogs")]
        public IActionResult AboutBluePrint(string id)        
        {
            siteName = id;
            if (siteControl.ValidateSiteName(id))
            {
                @ViewData["Site"] = id;
                var dataset = blog.GetBlogData(id);

                return View(dataset);
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

        [HttpPost]
        public async Task<IActionResult> EditorContent(Content content, IFormFile logo, IFormFile Banner, IFormFile objImg)
        {
            content.sitename = siteName;
            try
            {
                if (logo != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await logo.CopyToAsync(target);
                        content.logoImg = target.ToArray();
                    }
                }
                if (Banner != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await Banner.CopyToAsync(target);
                        content.BannerImg = target.ToArray();
                    }
                }
                if (objImg != null)
                {
                    using (var target = new MemoryStream())
                    {
                        await objImg.CopyToAsync(target);
                        content.ObjectImg = target.ToArray();
                    }
                }
                editor.UploadContent(content, siteName);
                return Redirect($"/{content.sitename}/admin/editor");

            }
            catch (Exception)
            {
                TempData["msgForEditor"] = "<script>alert('Oops! Something went wrong');</script>";
                return RedirectToAction($"/{content.sitename}/admin/editor");
            }
        }

    }
}
