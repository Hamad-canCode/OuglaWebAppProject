using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;

namespace OuglaWebApp.Controllers
{
    public class AdminController : Controller
    {
        
        bool ValidateSiteName = false;
        public static string siteName;
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

            if (ValidateSiteName==false)
            {
                if (siteControl.ValidateSiteName(id))
                {
                    siteName = id;
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
            if (signUp.LogIn(infoModel,siteName))
            {
                TempData["siteName"] = siteName;
                return RedirectToAction("BlogEditor", "Blog");
            }
            else
            {
                TempData["msg"] = "<script>alert('Oops! Something went wrong, Incorrect Name or Password Entred');</script>";
                return RedirectToAction("Admin",new { id=siteName});
            }
        }


        public IActionResult BlogEditor()
        {
            return View();
        }
    }
}
