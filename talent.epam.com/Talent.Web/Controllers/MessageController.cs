using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Talent.DAL;
using Talent.Web.Services;

namespace Talent.Web.Controllers
{
    public class MessageController : Controller
    {
        private EfContext _db = new EfContext();

        public async Task<HttpResponseMessage> SendEmail(string userids, string subject, string message)
        {
            var userIds = userids.Split(',').Select(Guid.Parse);
            var userEmails = _db.Users.Where(x => userIds.Contains(x.Id)).Select(x => x.Email);
            foreach(var email in userEmails)
            {
                await MessageService.SendEmail(email, subject, message);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        } 

        public async Task<HttpResponseMessage> SendSms(string userids, string message)
        {
            var userIds = userids.Split(',').Select(Guid.Parse);
            var userPhones = _db.Users.Where(x => userIds.Contains(x.Id)).Select(x => x.Phone);
            foreach (var phone in userPhones)
            {
                await MessageService.SendSms(phone, message);
            }
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}