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
    }
}
