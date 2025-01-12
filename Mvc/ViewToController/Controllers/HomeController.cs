using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ViewToController.Models;

namespace ViewToController.Controllers
{
    public class HomeController : Controller
    {

        //Get isteði gönderir.
        [HttpGet]//Atribute (özellik)
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string ad, string kisiler, bool onay = false)//Opsionel Parameters
        {
            var k1 = Request.Form["kisiler"];
            var a1 = Request.Form["ad"];
            var o1 = Request.Form["onay"];

            ViewBag.name = a1;
            return View();
        }

    }
}
