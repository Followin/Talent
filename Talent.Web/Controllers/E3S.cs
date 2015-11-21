using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent.Web.Parser;

namespace Talent.Web.Controllers
{
    public class E3SController : Controller
    {
        public async Task<ContentResult> Index()
        {
            E3SParser parser = new E3SParser("https://e3s.epam.com/who/evgeniy_khramtsov?tab=profile");
            var list = await parser.GetInterests();
            return Content("Index");
        }
    }
}