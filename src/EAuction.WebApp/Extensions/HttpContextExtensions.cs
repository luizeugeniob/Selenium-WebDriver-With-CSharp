using EAuction.Core;
using EAuction.WebApp.Extensions;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpContextExtensions
    {
        public static User GetLoggedUser(this HttpContext httpContext)
            => httpContext.Session.Get<User>("loggedUser");

        public static void SetAuthenticatedUser(this HttpContext httpContext, User user)
            => httpContext.Session.Set("loggedUser", user);

        public static void SetUnauthenticatedUser(this HttpContext httpContext)
            => httpContext.Session.Remove("loggedUser");
    }
}
