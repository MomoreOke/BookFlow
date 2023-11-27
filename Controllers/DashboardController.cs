using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Admin(IFormCollection coll)
        {
            return View();
        }

        public ActionResult Student() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Student(IFormCollection coll) 
        {
            return View();
        }

        public IActionResult GetBookName()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetBookName(string bookname)
        {
            return RedirectToAction("GetBookByBooKTitle","Books",new { booktitle =bookname });
        }



    }
}
