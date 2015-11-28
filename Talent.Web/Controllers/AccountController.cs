using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Talent.DAL;
using Talent.DAL.Models;
using Talent.Web.Models;

namespace Talent.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private EfContext _db = new EfContext();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<RedirectToRouteResult> Login(LoginModel model)
        {
            var user =
                await _db.Accounts.FirstOrDefaultAsync(x => x.Login == model.Login && x.Password == model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Login or password is invalid");
            }

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.Login,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(1),
                false,
                user.Id.ToString());
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(cookie);

            return RedirectToAction("Login", "Socials");
        }

        public ActionResult Logoff()
        {
            if (HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                HttpContext.Response.Cookies[FormsAuthentication.FormsCookieName].Value = String.Empty;
            }
            return RedirectToAction("Login");
        }
    }
}