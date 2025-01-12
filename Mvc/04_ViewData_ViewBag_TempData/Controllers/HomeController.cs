using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        /*Controller'dan view e veri taþýmak için kullanýlan yöntemler.
        1)ViewBag: Dinamik bir Özellik olup Controller'dan View'e veri taþýr
        2)ViewData:Sözlük(Dictionary) benzeri bir yapýdýr ve Controller'dan View'e veri taþýr.
        3)TempData:Geçici Veri taþýmak için kullanýlýr ve iki sonuc(action) arasýnda veri taþýr.


         */
        public IActionResult Index()
        {
            ViewBag.ad = "Erkan";
            ViewData["soyad"] = "Türk";
            TempData["cinsiyet"] = "erkek";
            ViewBag.onay = true;
            return View();
        }
        public IActionResult About()
        {
            ViewData["text"] = ViewData["soyad"];
            TempData["veri"] = TempData["cinsiyet"];

            ViewBag.dersler = new SelectListItem[]
            {
                new SelectListItem {Text="SQL"},
                new SelectListItem {Text="C#"},
                new SelectListItem{Text="JavaScript"}
            };
            return View();
        }


    }
}
