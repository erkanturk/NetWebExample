using _10_FluentValidation.Models;
using _10_FluentValidation.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_FluentValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<homePageViewModel> _validator;//fluent validation doðrulama iþlemi için kullanýlan validator nesnesi

        public HomeController(IValidator<homePageViewModel> validator)
        {
            _validator = validator;//Dependency injection ile validator nesnesi alma
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Submit(homePageViewModel model)
        {
            ValidationResult result = _validator.Validate(model);//model fluent validation kurallarýna göre kontrol et
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);//ModelState (durumu) hata mesajý
                }
                return View("Index", model);//Eðer burada if in içine girerse bir sorun vardýr o yüzden indexe geri yönlendir.
            }
            return RedirectToAction("Success");//Doðrulama baþarýlý ise Success Sayfasýna yönlendir
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}
