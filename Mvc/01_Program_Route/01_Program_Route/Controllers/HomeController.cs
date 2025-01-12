using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;//Proje i�erisindeki model s�n�flar�n� kullanmak i�in eklenen k�t�phane

namespace _01_Program_Route.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//Method=>Geriye IActionResult d�nd�ren bir method. IActionResult Geriye bir sonu� bir sayfa d�nderir.
        {
            return View(); // method geriye IActionResult d�nd�rmek zorunda oldu�undan geriye bir view d�nd�r�r�z Bu view =>Views/Home/Index
        }
        public IActionResult About()
        {
            return View();//About ad�nda bir view'i d�nderir View kullan�c�ya g�sterilecek Html ��kt�s�n� temsil eder.
        }
    }
}
