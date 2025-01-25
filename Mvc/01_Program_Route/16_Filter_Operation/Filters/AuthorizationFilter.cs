using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _16_Filter_Operation.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        //Burada basit bir kullanıcı login oldumu kontrolü yapıyoruz.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                // eğer kullanıcı login olmadıysa login sayfasına yönlendir.
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
