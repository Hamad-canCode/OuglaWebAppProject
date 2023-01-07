using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OuglaWebApp.DataLogic;

namespace OuglaWebApp.Controllers
{
    public class SiteDisplayController : Controller
    {

        SiteControll siteControl = null;
        public static string siteName;
        public SiteDisplayController(SiteControll siteControle)
        {
            siteControl = siteControle;
        }

        [Route("/{id}")]
        public IActionResult HomeBluePrint(string id)
        {
            if (siteControl.ValidateSiteName(id))
            {
                siteName = id;
                @ViewData["Site"] = id;
                return View();
            }
            else
            {
                return View("Error404");
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

        //public IActionResult OpenSite(string id) 
        //{

        //}
    }
}
