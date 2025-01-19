using _12_Dependecy_Injection.Models;
using _12_Dependecy_Injection.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependecy_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMyService _myservice;
        public HomeController(IMyService myService)
        {
            _myservice = myService;
        }
        public IActionResult Index()
        {
            List<Student> students = _myservice.GetStudents();
            return View(students);
        }

      
    }
}
