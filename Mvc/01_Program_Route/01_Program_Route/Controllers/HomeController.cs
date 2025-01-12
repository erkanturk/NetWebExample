using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;//Proje içerisindeki model sýnýflarýný kullanmak için eklenen kütüphane

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//Method=>Geriye IActionResult döndüren bir method. IActionResult Geriye bir sonuç bir sayfa dönderir.
        {
            return View(); // method geriye IActionResult döndürmek zorunda olduðundan geriye bir view döndürürüz Bu view =>Views/Home/Index
        }
        public IActionResult About()
        {
            return View();//About adýnda bir view'i dönderir View kullanýcýya gösterilecek Html Çýktýsýný temsil eder.
        }
    }
}
