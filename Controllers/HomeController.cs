using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagement.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomePageModel
            {
                WelcomeMessage = "WELCOME TO BOOKFLOW"
                // Set other properties as needed
            };

            return View(model);
        }
    }
}
