using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HtmlAgilityPack;
using Newtonsoft.Json.Linq;
using Talent.DAL;
using Talent.DAL.Models;
using Talent.Web.Models;
using Talent.Web.Static;

namespace Talent.Web.Controllers
{
    public class SocialsController : Controller
    {
        private EfContext _db;
        private HttpClient _client;
        private Dictionary<string, AuthModel> _socialModels;

        public SocialsController()
        {
            _db = new EfContext();
            _client = new HttpClient();
        }

        private Account GetCurrentAccount()
        {
            var cookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null || String.IsNullOrWhiteSpace(cookie.Value))
            {
                return null;
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            Guid id;

            if (ticket == null || !Guid.TryParse(ticket.UserData, out id))
            {
                return null;
            }

            var account = _db.Accounts.Find(id);

            return account;

        }

        public ActionResult Login()
        {
            var vkModel = new AuthModel
            {
                ApiId = Constants.VkApiId,
                RedirectUri = Url.Action("Vk", "Socials", null, Request.Url.Scheme),
                Scope = "friends, groups"
            };

            var linkedInModel = new LinkedInAuthModel()
            {
                RedirectUri = Url.Action("LinkedIn", "Socials", null, Request.Url.Scheme),
                ApiId = Constants.LinkedInClientId,
                State = Guid.NewGuid().ToString()
            };

            return View(new SocialsViewModel() { LinkedIn = linkedInModel, Vk = vkModel });
        }

        public async Task<ActionResult> LinkedIn(string code)
        {
            await GetLinkedInSkills(code);

            return View("CloseTab");
        }

        public async Task<ViewResult> Vk(string code)
        {
            await AddVkUser(code);

            return View("CloseTab");
        }

        private async Task GetLinkedInSkills(string token)
        {
            var htmlDocument = new HtmlDocument();
            var values = new Dictionary<string, string>
            {
                {"grant_type", Constants.LinkedInGrantType},
                {"code", token},
                {"redirect_uri", Url.Action("LinkedIn", "Socials", null, Request.Url.Scheme)},
                {"client_id", Constants.LinkedInClientId},
                {"client_secret", Constants.LinkedInClientSecret}
            };

            var postContent = new FormUrlEncodedContent(values);

            var responseMessage = await _client.PostAsync(Constants.LinkedInOAuth2Url, postContent);

            var contentString = await responseMessage.Content.ReadAsStringAsync();
            var contentJson = JObject.Parse(contentString);
            var tokenAuth = contentJson["access_token"];

            var url = string.Format("{0}~:(public-profile-url)?oauth2_access_token={1}&format=json", Constants.LinkedInPeopleUrl, tokenAuth);

            string userInfo = await _client.GetStringAsync(url);
            var jsonUserInfo = JObject.Parse(userInfo);
            var userUrl = jsonUserInfo["publicProfileUrl"].ToString();

            var str = await _client.GetStringAsync(userUrl);

            htmlDocument.LoadHtml(str);

            var skillsNodes = htmlDocument.DocumentNode.SelectNodes("//li[@class='skill']");

            var skills = new List<string>();

            if (skillsNodes != null)
            {
                skills = skillsNodes.Select(node => node.InnerText).ToList();
            }

            var skillsToAdd = skills.Except(await _db.Skills.Select(skill => skill.Name).ToListAsync());

            skillsToAdd.ToList().ForEach(s => _db.Skills.Add(new Skill { Name = s }));

            await _db.SaveChangesAsync();


            var currentAccount = GetCurrentAccount();
            User currentUser;
            if (currentAccount.User == null)
            {
                currentUser = _db.Users.Add(new User());
                currentAccount.User = currentUser;
            }
            else
            {
                currentUser = currentAccount.User;
            }


            foreach (var toDel in currentUser.Skills.Select(x => x.Name).Except(skills))
            {
                var del = await _db.Skills.FirstOrDefaultAsync(x => x.Name == toDel);
                currentUser.Skills.Remove(del);
            }

            foreach (var toAdd in skills.Except(currentUser.Skills.Select(x => x.Name)))
            {
                var add = await _db.Skills.FirstOrDefaultAsync(x => x.Name == toAdd);
                currentUser.Skills.Add(add);
            }

            await _db.SaveChangesAsync();
        }

        private async Task AddVkUser(string code)
        {
            var redirectUri = Url.Action("Vk", "Socials", null, Request.Url.Scheme);

            var url = string.Format("{0}?client_id={1}&client_secret={2}&code={3}&redirect_uri={4}",
                @"https://oauth.vk.com/access_token", Constants.VkApiId, Constants.VkSecret, code, redirectUri);

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

            var currentAccount = GetCurrentAccount();

            User user;
            user = await _db.Users.FirstOrDefaultAsync(x => x.VkId == userId) ?? currentAccount.User;


            if (user == null)
            {
                user = _db.Users.Add(new User
                {
                    VkId = userId,
                    FirstName = firstName,
                    LastName = lastName
                });
                
                currentAccount.User = user;
                _db.Entry(currentAccount).State = EntityState.Modified;
            }

            user.FirstName = firstName;
            user.LastName = lastName;

            if (user.Interests == null)
            {
                user.Interests = resultInterests;
            }
            else
            {
                foreach (var toDel in user.Interests.Except(resultInterests))
                {
                    user.Interests.Remove(toDel);
                }

                foreach (var toAdd in resultInterests.Except(user.Interests))
                {
                    user.Interests.Add(toAdd);
                }
            }

            

            await _db.SaveChangesAsync();
        }

        

        public ActionResult Info()
        {
            //var users = _db.Users.Select(x => new
            //{
                
            //})

            var user = GetCurrentAccount().User;
            return Json(new
            {
                Name = user.FirstName + ' ' + user.LastName,
                Skills = user.Skills.Select(x => new {Id = x.Id, Name = x.Name}),
                Interests = user.Interests.Select(x => new { Id = x.Id, Name = x.TitleRu })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}