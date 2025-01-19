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
        private readonly IValidator<homePageViewModel> _validator;//fluent validation do�rulama i�lemi i�in kullan�lan validator nesnesi

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
            ValidationResult result = _validator.Validate(model);//model fluent validation kurallar�na g�re kontrol et
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);//ModelState (durumu) hata mesaj�
                }
                return View("Index", model);//E�er burada if in i�ine girerse bir sorun vard�r o y�zden indexe geri y�nlendir.
            }
            return RedirectToAction("Success");//Do�rulama ba�ar�l� ise Success Sayfas�na y�nlendir
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}
