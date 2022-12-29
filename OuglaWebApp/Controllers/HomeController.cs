using Microsoft.AspNetCore.Mvc;
using OuglaWebApp.DataLogic;
using OuglaWebApp.Models;
using System.Diagnostics;

namespace OuglaWebApp.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly SignUp signup = null;

        private readonly ILogger<HomeController> _logger;

        public HomeController(SignUp signUp, ILogger<HomeController> logger)
        {
            signup = signUp;
            _logger = logger;
        }

        //Get Controller
        public IActionResult Index()
        {
            ViewData["validate"] = true;
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Info infoModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    signup.AddNewUser(infoModel);
                    ViewData["validate"] = signup.validSiteName;
                    if (signup.validSiteName)
                    {
                        signup.CreateBlogTable(infoModel);
                        return Redirect("/"+infoModel.Sitename);
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}