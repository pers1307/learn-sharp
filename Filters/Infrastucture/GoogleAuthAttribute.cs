using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace Filters.Infrastucture
{
    public class GoogleAuthAttribute : FilterAttribute, IAuthenticationFilter
    {
        /**
         * Проверяет авторизацию
         */
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            IIdentity ident = filterContext.Principal.Identity;

            if (!ident.IsAuthenticated || !ident.Name.EndsWith("@google.com"))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        /**
         * Вызывается каждый раз, когда авторизация не пройдена
         * Вызывается также после выполнения самого метода 
         */
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary{
                    {"controller", "GoogleAccount"},
                    {"action", "Login"},
                    {"returnUrl", filterContext.HttpContext.Request.RawUrl},
                });
            }
            else
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}