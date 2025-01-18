using _05_Html_Helpers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _05_Html_Helpers.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            User user = new User();
            user.CountryList = GetCountries();
            user.Name = "Erkan";
            return View(user);
        }
        [HttpPost]
        public IActionResult Submit(User user)
        {
            //Bir if yapýsý var ise koþulun içerisine girmeye bilir bu yüzden sayfayý geriye return edemez dýþarý alanda da 
            //bir return iþlemi yapmak gereklidir.
            var test = ModelState.IsValid;
            if (ModelState.IsValid)
            {
                ViewBag.Message = $"Name: {user.Name} - Age: {user.Age} - Gender: {user.Gender} - Country: {user.Country} ";
                return View("Result");
            }
            return View("Index");

        }
        public IActionResult Result()
        {
            return View();
        }
        public IEnumerable<SelectListItem> GetCountries()
        {
            return new SelectListItem[] 
            {
                new SelectListItem () {Value="TR", Text="Türkiye"},
                new SelectListItem () {Value="US", Text="USA"},
                new SelectListItem () {Value="UK", Text="Ýngiltere"},
                new SelectListItem () {Value="JP", Text="Japonya"}
            };
        }

    }
}
