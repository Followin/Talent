﻿using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Talent.Web.Models;
using Talent.Web.Static;

namespace Talent.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string ApiId = "5157103";
        private const string Secret = "KP62F9De2olW4F4CgQPk";

        private HttpClient _client;

        public HomeController()
        {
            _client = new HttpClient();

        }

        public ActionResult Index()
        {
            var redirectUri = Url.Action("Code", "Home", null, Request.Url.Scheme);


            var model = new VkAuthModel
            {
                ApiId = "5157103",
                RedirectUri = redirectUri,
                Scope = "friends, groups"
            };

            return View(model);
        }

        private async Task AddVkUser(string code)
        {
            var redirectUri = Url.Action("Code", "Home", null, Request.Url.Scheme);

            var url = string.Format("{0}?client_id={1}&client_secret={2}&code={3}&redirect_uri={4}",
                @"https://oauth.vk.com/access_token", ApiId, Secret, code, redirectUri);

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

            var existingUser = UsersList.Users.Find(x => x.Id == userId);
            if (existingUser == null)
            {
                UsersList.Users.Add(new User
                {
                    Id = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Groups = groupNames.ToArray(),
                    Interests = interests,
                });
            }
        }

        public async Task<ActionResult> Code(string code)
        {
            await AddVkUser(code);

            return View("CloseTab");
        }

        public ActionResult ShowToken(string str)
        {
            return View("ShowString", (object)str);
        }

        public ActionResult ShowUsers()
        {
            return Json(UsersList.Users, JsonRequestBehavior.AllowGet);
        }
    }
}