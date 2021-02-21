using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace StructuredMarkupHelper.Core.Infrastructure
{
    public class HeadlessBrowser
    {
        private static HttpClient httpClient = new HttpClient();
        private static ConcurrentDictionary<string, string> loadedHtmls = new ConcurrentDictionary<string, string>();

        private static List<string> validHtmlContentTags = new List<string>
        {
            "article","p","h1","h2","h3","h4","h5"
        };

        public string GetHtmlText(string phantomCloudUrl, string url)
        {
            if (loadedHtmls.Count > 100)
            {
                loadedHtmls.Clear();
            }

            if (loadedHtmls.TryGetValue(url, out string html) == false)
            {
                httpClient.DefaultRequestHeaders.ExpectContinue = false;

                var httpContent = new StringContent(JsonConvert.SerializeObject(new
                {
                    url = url,
                    //renderType = "plainText",
                    outputAsJson = true
                }), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(phantomCloudUrl, httpContent).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;

                var result = JObject.Parse(responseString);

                html = result.SelectToken("$.pageResponses[-1:].frameData.content").Value<string>();

                loadedHtmls.TryAdd(url, html);
            }

            return html;
        }

        public string GetContent(HtmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();

            TraverseContentChilds(doc.DocumentNode, sb);

            return sb.ToString();
        }

        private void TraverseContentChilds(HtmlNode node, StringBuilder sb)
        {
            if(node.Id == "CybotCookiebotDialog")
            {
                return;
            }

            if (validHtmlContentTags.Contains(node.Name))
            {
                sb.Append($" {node.InnerText} ");
                return;
            }

            foreach (var c in node.ChildNodes)
            {
                TraverseContentChilds(c, sb);
            }
        }
    }
}
