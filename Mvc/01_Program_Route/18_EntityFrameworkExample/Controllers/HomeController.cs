using _18_EntityFrameworkExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _18_EntityFrameworkExample.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

     
    }
}
