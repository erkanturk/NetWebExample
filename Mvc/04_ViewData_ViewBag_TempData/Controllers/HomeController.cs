using _04_ViewData_ViewBag_TempData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace _04_ViewData_ViewBag_TempData.Controllers
{
    public class HomeController : Controller
    {
        /*Controller'dan view e veri ta��mak i�in kullan�lan y�ntemler.
        1)ViewBag: Dinamik bir �zellik olup Controller'dan View'e veri ta��r
        2)ViewData:S�zl�k(Dictionary) benzeri bir yap�d�r ve Controller'dan View'e veri ta��r.
        3)TempData:Ge�ici Veri ta��mak i�in kullan�l�r ve iki sonuc(action) aras�nda veri ta��r.


         */
        public IActionResult Index()
        {
            ViewBag.ad = "Erkan";
            ViewData["soyad"] = "T�rk";
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
