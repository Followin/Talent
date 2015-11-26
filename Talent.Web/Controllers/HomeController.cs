using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Talent.DAL;
using Talent.DAL.Models;
using Talent.Web.Models;
using Talent.Web.Static;

namespace Talent.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string VkApiId = "5157103";
        private const string VkSecret = "KP62F9De2olW4F4CgQPk";
        private const string LinkedinApiId = "77drty6p9okcfs";
        private const string LinkedinSecret = "RNJjGFRmBJAQFvDL";

        private EfContext _db = new EfContext();

        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();

        }

        public ActionResult Index()
        {
            var redirectUri = Url.Action("Code", "Home", null, Request.Url.Scheme);


            var vkmodel = new AuthModel
            {
                ApiId = VkApiId,
                RedirectUri = redirectUri,
                Scope = "friends, groups"
            };

            var linkedRedirectUri = Url.Action("LinkedinCode", "Home", null, Request.Url.Scheme);

            var linkedInModel = new LinkedInAuthModel
            {
                ApiId = LinkedinApiId,
                RedirectUri = linkedRedirectUri,
                State = Guid.NewGuid().ToString()
            };

            var socialsViewModel = new SocialsViewModel
            {
                LinkedIn = linkedInModel,
                Vk = vkmodel
            };

            return View(socialsViewModel);
        }

        private async Task AddVkUser(string code)
        {
            var redirectUri = Url.Action("Code", "Home", null, Request.Url.Scheme);

            var url = string.Format("{0}?client_id={1}&client_secret={2}&code={3}&redirect_uri={4}",
                @"https://oauth.vk.com/access_token", VkApiId, VkSecret, code, redirectUri);

            var str = await _client.GetStringAsync(url);
            var jobj = JObject.Parse(str);

            var accessToken = jobj["access_token"].ToString();
            var userId = jobj["user_id"].ToString();
            var fields = "uid, first_name, last_name, screen_name, sex, bdate, interests";
            var requestUrl = string.Format("{0}?fields={1}&uids={2}&access_token={3}",
                @"https://api.vk.com/method/users.get", fields, userId, accessToken);
            var result = await _client.GetStringAsync(requestUrl);
            var resultObj = (JObject.Parse(result)["response"] as JArray)[0];
            var interests = resultObj["interests"].ToString().Split(',');
            var firstName = resultObj["first_name"].ToString();
            var lastName = resultObj["last_name"].ToString();

            var groupsUrl = string.Format("{0}?extended=1&user_id={1}&access_token={2}", @"https://api.vk.com/method/groups.get",
                userId, accessToken);
            result = await _client.GetStringAsync(groupsUrl);
            var groups = (JObject.Parse(result)["response"] as JArray);

            var groupNames = groups.Skip(1).Select(x => x["name"].ToString());

            var resultInterests = new List<Interest>();
            foreach (var group in groupNames)
            {
                var synonym = _db.Synonyms.ToList().FirstOrDefault(x => Regex.IsMatch(group, x.Text));
                if (synonym != null)
                {
                    resultInterests.Add(synonym.Interest);
                }
            }

            var existingUser = await _db.Users.FindAsync(userId);
            if (existingUser == null)
            {
                _db.Users.Add(new User
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Interests = resultInterests
                });
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ActionResult> Code(string code)
        {
            await AddVkUser(code);

            return View("CloseTab");
        }



        public async Task<ActionResult> LinkedinCode(string code)
        {
            return View("ShowString", code as object);
        }

        public ActionResult ShowToken(string str)
        {
            return View("ShowString", (object)str);
        }

        public async Task<JsonResult> ShowUsers()
        {
            var users = await _db.Users.ToListAsync();
            return Json(users.Select(x => new { Name = x.FirstName + ' ' + x.LastName, Interests = x.Interests.Select(y => new { Title = y.TitleEn })}), JsonRequestBehavior.AllowGet);
        }
    }
}