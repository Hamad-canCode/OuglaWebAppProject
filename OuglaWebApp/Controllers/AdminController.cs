using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;

namespace OuglaWebApp.Controllers
{
    public class AdminController : Controller
    {
        
        bool ValidateSiteName = false;
        SiteControll siteControl = null;
        SignUp signUp = null;

        public AdminController(SiteControll siteControle, SignUp signUp)
        {
            this.siteControl = siteControle;
            this.signUp = signUp;
        }

        [Route("/{id}/admin")]
        public IActionResult Admin(string id)
        {
            var site = id;
            if (ValidateSiteName==false)
            {
                if (siteControl.ValidateSiteName(id))
                {
                    
                    ValidateSiteName = true;
                    return View("~/Views/Admin/AdminLogin.cshtml");
                }
                else
                {
                    return View("Error404");
                }
            }
            else
            {
                return View("~/Views/Admin/AdminLogin.cshtml");
            }
            
        }

        [HttpPost]
        public IActionResult AdminLogin(Info infoModel)
        {
            if (signUp.LogIn(infoModel))
            {
                return View("Editor");
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }
    }
}
