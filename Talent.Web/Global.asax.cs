using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Talent.DAL;

namespace Talent.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
        }

        protected void Application_PostAuthenticateRequest()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || String.IsNullOrWhiteSpace(cookie.Value))
            {
                return;
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            Guid id;

            if (ticket == null || !Guid.TryParse(ticket.UserData, out id))
            {
                return;
            }

            var db = new EfContext();
            var account = db.Accounts.Find(id);
            if (account == null)
            {
                return;
            }

            var identity = new GenericIdentity(account.Login);
            HttpContext.Current.User = new GenericPrincipal(identity, new string[0]);
        }
    }
}
