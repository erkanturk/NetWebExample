
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToview.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "�r�n 1", "�r�n 2", "�r�n 3","�r�n 4","�r�n 5" };
            //Veriyi View data ile view e yollama
            ViewData["Products"] = products;
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = $"�r�n {id} Detaylar�";

            ViewData["Product"] = product;
            return View();
        }
    }
}
