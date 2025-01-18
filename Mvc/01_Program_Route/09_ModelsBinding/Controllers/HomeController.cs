using _09_ModelsBinding.Models;
using _09_ModelsBinding.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_ModelsBinding.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult HomePage()
        {
            Kisi kisi = new Kisi()//kiþi nesnesi deðerleri
            {
                Ad = "Erkan",
                Soyad = "Türk",
                Yas = 30
            };
            return View(kisi);//kiþi nesnesini döndür.
        }
        // iki farklý modeli (Kiþi ve Adres) bir View'e göndermek için ViewModel kullanýmý
        public IActionResult HomePage2()
        {
            //Buradaki sorun 2 modeli tek bir model gibi yollayabilmek.
            //bu durum için viewmodel kavramý kullanýlýr.

            Kisi kisi = new Kisi()
            {
                Ad = "Erkan",
                Soyad = "Türk",
                Yas = 30
            };
            Adres adres = new Adres()
            {
                AdresTanim = "KAdýköy/Caferaða mah.",

                Sehir = "Ýstanbul"
            };
            homePageViewModel viewModel = new homePageViewModel();
            viewModel.AdresNesnesi = adres;// Yukarýda oluþturduðumuz adres nesnesi ViewModel'e atanýyor
            viewModel.KisiNesnesi = kisi;//Yukarýda oluþturduðumuz kiþi nesnesi ViewModel' atanýyor
            return View(viewModel);// ViewModel nesnesi artýk 2 nesneyede sahip bunlarý görüntüleme tarafýnda yardýmcý oluyor.
        }


    }
}
