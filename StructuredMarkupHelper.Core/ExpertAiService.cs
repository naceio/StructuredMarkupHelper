using ExpertIO.Client.Api;
using ExpertIO.Client.Client;
using ExpertIO.Client.Model;
using Newtonsoft.Json;
using StructuredMarkupHelper.Core.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace StructuredMarkupHelper.Core
{
    public class ExpertAiService
    {
        ExpertAiAuth auth;

        private static object tokenLock = new object();
        private static string storedToken;
        private static HttpClient httpClient = new HttpClient();

        public void SetAuthentication(ExpertAiAuth auth)
        {
            this.auth = auth;
        }

        public CategorizeResponse IptcCategorize(AnalysisRequest analysisRequest)
        {
            Configuration c = new Configuration
            {
                AccessToken = GenerateToken()
            };

            var classificationApi = new DocumentClassificationApi(c);

            var result = classificationApi.CategorizeTaxonomyLanguagePost("iptc", "en", analysisRequest: analysisRequest);

            return result;
        }

        private string GenerateToken()
        {
            if (string.IsNullOrEmpty(auth?.Token) && string.IsNullOrEmpty(auth?.Username))
            {
                throw new InvalidOperationException($"Please provide Expert.ai credentials");
            }

            if (string.IsNullOrEmpty(auth.Token) == false)
            {
                if (IsTokenExpired(auth.Token))
                {
                    throw new InvalidOperationException($"Provided token is expired");
                }

                return auth.Token;
            }

            if (string.IsNullOrEmpty(auth.TokenRequestEndpoint))
            {
                throw new InvalidOperationException($"Token request endpoint is not provided");
            }

            if (string.IsNullOrEmpty(storedToken) == false)
            {
                if (IsTokenExpired(storedToken) == false)
                {
                    return storedToken;
                }
            }

            lock (tokenLock)
            {
                if (string.IsNullOrEmpty(storedToken) == false)
                {
                    if (IsTokenExpired(storedToken) == false)
                    {
                        return storedToken;
                    }
                }

                var httpContent = new StringContent(JsonConvert.SerializeObject(new
                {
                    username = auth.Username,
                    password = auth.Password
                }), Encoding.UTF8, "application/json");

                var httpResponse = httpClient.PostAsync(auth.TokenRequestEndpoint, httpContent).Result;

                if (httpResponse.Content != null)
                {
                    storedToken = httpResponse.Content.ReadAsStringAsync().Result;

                    return storedToken;
                }

                throw new InvalidOperationException($"an error happened during Expert.ai token request");
            }
        }

        private bool IsTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token) as JwtSecurityToken;

            var dto = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(jsonToken.Claims.First(x => x.Type == "exp").Value) * Convert.ToInt64(Math.Pow(10, 3)));

            var remainingHours = dto.Subtract(DateTimeOffset.UtcNow).TotalHours;

            return remainingHours <= 2;
        }
    }
}
