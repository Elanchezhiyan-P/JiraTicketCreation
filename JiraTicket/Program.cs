using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace JiraTicket
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            string ProjectName = "";
            var jsonstru = $@"{{
    ""fields"": {{
        ""project"": {{
            ""key"": ""{ProjectName}""
        }},
        ""summary"": ""Test API"",
        ""issuetype"": {{
            ""name"": ""Task""  
        }},
        ""description"": {{
            ""content"": [
                {{
                    ""content"": [
                        {{
                            ""text"": ""This is an detailed description for the jira ticket creation process from API 3."",
                            ""type"": ""text""
                        }}
                    ],
                    ""type"": ""paragraph""
                }}
            ],
            ""type"": ""doc"",
            ""version"": 1
        }},
        ""priority"": {{
            ""name"": ""High""
        }},
        ""labels"": [
            ""APITicket""
        ]
    }}
}}";

            var username = "xxxxxx";
            var password = "xxxxxx";

            var httpClient = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, "https://{xxxxxx}.atlassian.net/rest/api/3/issue")
            {
                Content = new StringContent(jsonstru, Encoding.UTF8, "application/json")
            };

            var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);

            HttpResponseMessage response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseContent);
            }
        }
    }
}
