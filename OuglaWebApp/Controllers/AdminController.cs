﻿using Microsoft.AspNetCore.Mvc;
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
                    TempData["site"] = siteName;

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

                TempData["logged"]= true;
                TempData["verified"] = true;
                return Redirect("/" + siteName+ "/admin/editor");
               
            }
            else
            {
                TempData["msg"] = "Incorrect Name or Password";
                return RedirectToAction("Admin",new { id=siteName});
            }
        }
    }
}
