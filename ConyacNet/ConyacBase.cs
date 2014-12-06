using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet.Standard
{
    public class CallResult
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("message")]
        public string Message;

    }


    public class ConyacBase : IDisposable
    {
        protected readonly HttpClient m_Client = new HttpClient();

        protected bool m_UseDevelopmentService;

        protected string m_AccessToken;

        protected const string StrServiceUrl = "https://biz.conyac.cc/";
        protected const string StrServiceUrlDev = "https://biz.dev-conyac.com/";


        protected ConyacBase()
        {
            m_UseDevelopmentService = false;
        }


        public void Dispose()
        {
            m_Client.Dispose();
        }

        protected async Task<string> PostJson(Uri url, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await m_Client.PostAsync(url, content);
            var responseBody = await result.Content.ReadAsStringAsync();

            return responseBody;
        }

        protected CallResult ParseCallResult(string result)
        {
            return JsonConvert.DeserializeObject<CallResult>(result);
        }

        protected NameValueCollection GetQueryStringCollection()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["access_token"] = m_AccessToken;
            return queryString;
        }

        public string ServiceUrl
        {
            get
            {
                if (m_UseDevelopmentService)
                {
                    return StrServiceUrlDev;
                }
                return StrServiceUrl;
            }
        }




    }

}
