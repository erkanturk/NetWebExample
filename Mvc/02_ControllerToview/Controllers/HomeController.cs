
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_ControllerToview.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<string> { "Ürün 1", "Ürün 2", "Ürün 3","Ürün 4","Ürün 5" };
            //Veriyi View data ile view e yollama
            ViewData["Products"] = products;
            return View();
        }
        public IActionResult Details(int id)
        {
            var product = $"Ürün {id} Detaylarý";

            ViewData["Product"] = product;
            return View();
        }
    }
}
