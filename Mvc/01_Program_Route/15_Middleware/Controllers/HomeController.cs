using _15_Middleware.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _15_Middleware.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

      
    }
}
