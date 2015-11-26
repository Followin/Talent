using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Talent.Web.Models;
using Talent.Web.Parser;

namespace Talent.Web.Controllers
{
    public class E3SController : Controller
    {
        private const string ClientId = "77uisk4o35h5f2";

        public ActionResult Index()
        {
            var model = new LinkedInAuthModel()
            {
                ApiId = ClientId,
                RedirectUri = Url.Action("Code", "E3S", null, Request.Url.Scheme),
                State = "qwerty"
            };

            return View(model);
        }

        private async Task<List<string>> ParseSkills(string token)
        {
            var htmlDocument = new HtmlDocument();
            var httpClient = new HttpClient();
            var values = new Dictionary<string, string>
            {
                {"grant_type", "authorization_code"},
                {"code", token},
                {"redirect_uri", Url.Action("Code", "E3S", null, Request.Url.Scheme)},
                {"client_id", "77uisk4o35h5f2"},
                {"client_secret", "vCUwOvR8JZVloIJl"}
            };

            var postContent = new FormUrlEncodedContent(values);

            var responseMessage = await httpClient.PostAsync("https://www.linkedin.com/uas/oauth2/accessToken", postContent);

            var contentString = await responseMessage.Content.ReadAsStringAsync();
            var contentJson = JObject.Parse(contentString);
            var tokenAuth = contentJson["access_token"];

            var url = string.Format(@"https://api.linkedin.com/v1/people/~:(public-profile-url)?oauth2_access_token={0}&format=json", tokenAuth);
  
            string userInfo = await httpClient.GetStringAsync(url);
            var jsonUserInfo = JObject.Parse(userInfo);
            var userUrl = jsonUserInfo["publicProfileUrl"].ToString();

            var str = await httpClient.GetStringAsync(userUrl);

            htmlDocument.LoadHtml(str);

            var skillsNodes = htmlDocument.DocumentNode.SelectNodes("//li[@class='skill']");

            var skills = new List<string>();

            if (skillsNodes != null)
            {
                skills = skillsNodes.Select(node => node.InnerText).ToList();
            }

            return skills;
        }

        public async Task<ContentResult> Code(string code)
        {
            var skills = await ParseSkills(code);
            return Content(string.Join(", ", skills));
        }
    }
}