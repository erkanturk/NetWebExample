using Microsoft.AspNetCore.Mvc;

namespace _16_Filter_Operation.Controllers
{
    public class AccountController:Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
