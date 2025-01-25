
using _13_LifeCycle.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_LifeCycle.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransientRandomNumberService _transientService;//ilk istek
        private readonly TransientRandomNumberService _transientService1;// ayný yapýdan Ýkinci istek
        private readonly ScopedHelperService _scopedHelperService;//ilk istek
        private readonly ScopedHelperService _scopedHelperService1;//ayný yapýdan Ýkinci istek
        private readonly SingletonRandomNumberService _singletonService;//ilk istek
        private readonly SingletonRandomNumberService _singletonService1;//Ayný yapýda ikinci istek

        public HomeController(TransientRandomNumberService transientRandomNumberService,TransientRandomNumberService transientRandomNumberService1,ScopedHelperService scopedHelperService, ScopedHelperService scopedHelperService1, SingletonRandomNumberService singletonRandomNumberService , SingletonRandomNumberService singletonRandomNumberService1)
        {
            _transientService = transientRandomNumberService;
            _transientService1 = transientRandomNumberService1;
            _scopedHelperService = scopedHelperService;
            _scopedHelperService1 = scopedHelperService1;
            _singletonService = singletonRandomNumberService;
            _singletonService1 = singletonRandomNumberService1;

        }

        public IActionResult Index()
        {
            //ayný http isteðinde Scoped Transeid ve Singleton karþýlaþtýrmasý
            var transientValue1 = _transientService.GetRandomNumber();
            var transientValue2 = _transientService1.GetRandomNumber();

            var scopedValue1 = _scopedHelperService.GetScopedNumber();
            var scopedValue2 = _scopedHelperService1.GetScopedNumber();

            var singletonValue1 = _singletonService.GetRandomNumber();
            var singletonValue2 = _singletonService1.GetRandomNumber();

            ViewBag.Transient1 = transientValue1;
            ViewBag.Transient2 = transientValue2;

            ViewBag.Scoped1 = scopedValue1;
            ViewBag.Scoped2 = scopedValue2;

            ViewBag.Singleton1 = singletonValue1;
            ViewBag.Singleton2 = singletonValue2;
            return View();
        }

      

      
    }
}
