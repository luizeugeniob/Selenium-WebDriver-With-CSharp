using EAuction.Core;
using EAuction.WebApp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EAuction.WebApp.Filters
{
    public class AuthorizationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.Get<User>("loggedUser") == null)
                context.Result = new RedirectToActionResult("Login", "Autenticacao", null);
        }
    }
}
