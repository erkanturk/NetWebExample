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
            Kisi kisi = new Kisi()//ki�i nesnesi de�erleri
            {
                Ad = "Erkan",
                Soyad = "T�rk",
                Yas = 30
            };
            return View(kisi);//ki�i nesnesini d�nd�r.
        }
        // iki farkl� modeli (Ki�i ve Adres) bir View'e g�ndermek i�in ViewModel kullan�m�
        public IActionResult HomePage2()
        {
            //Buradaki sorun 2 modeli tek bir model gibi yollayabilmek.
            //bu durum i�in viewmodel kavram� kullan�l�r.

            Kisi kisi = new Kisi()
            {
                Ad = "Erkan",
                Soyad = "T�rk",
                Yas = 30
            };
            Adres adres = new Adres()
            {
                AdresTanim = "KAd�k�y/Cafera�a mah.",

                Sehir = "�stanbul"
            };
            homePageViewModel viewModel = new homePageViewModel();
            viewModel.AdresNesnesi = adres;// Yukar�da olu�turdu�umuz adres nesnesi ViewModel'e atan�yor
            viewModel.KisiNesnesi = kisi;//Yukar�da olu�turdu�umuz ki�i nesnesi ViewModel' atan�yor
            return View(viewModel);// ViewModel nesnesi art�k 2 nesneyede sahip bunlar� g�r�nt�leme taraf�nda yard�mc� oluyor.
        }


    }
}
