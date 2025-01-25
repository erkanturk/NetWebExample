using _16_Filter_Operation.Filters;
using _16_Filter_Operation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace _16_Filter_Operation.Controllers
{
    public class HomeController : Controller
    {

        [ServiceFilter(typeof (ActionFilter))]
        public IActionResult Index()
        {
            return View();
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult Privacy()
        {
            return View();
        }
        [ServiceFilter(typeof(ExceptionFilter))]
        public IActionResult SpecialAction()
        {
            throw new Exception("Bu bir test hatasýdýr.");
        }


    }
}
