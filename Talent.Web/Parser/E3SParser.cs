using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace Talent.Web.Parser
{
    public class E3SParser
    {
        private string _url;

        public E3SParser(string url)
        {
            _url = url;
        }

        public async Task<List<string>> GetInterests()
        {
            var html = new HtmlDocument();
            var httpClient = new HttpClient();
            var str = await httpClient.GetStringAsync(_url);

            html.LoadHtml(str);
            var node = html.DocumentNode.SelectNodes("//form").First();
            var action = html.DocumentNode.SelectNodes("//form").First().Attributes["action"].Value;
            var token = html.DocumentNode.SelectNodes("//form").First().NextSibling.NextSibling.Attributes["value"].Value;
            var tokenReturnUrl = html.DocumentNode.SelectNodes("//form").First().NextSibling.NextSibling.NextSibling.NextSibling.Attributes["value"].Value;

            var values = new Dictionary<string, string>();
            values.Add("RelayState", tokenReturnUrl);
            values.Add("SAMLRequest", token);
            var content = new FormUrlEncodedContent(values);

            var httpResponseMessage = await httpClient.PostAsync(action, content);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var a = "hello";
            }

            values = new Dictionary<string, string>();
            values.Add("RelayState", tokenReturnUrl);
            values.Add("SAMLResponse", token);
            content = new FormUrlEncodedContent(values);

            httpResponseMessage = await httpClient.PostAsync("https://e3s.epam.com:443/mellon/postResponse", content);

            if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
            {
                var abc = "hello";
            }

            return new List<string>();
        }
    }
}