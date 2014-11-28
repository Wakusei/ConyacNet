using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConyacNet
{
    public class CallResult
    {
        [JsonProperty("success")]
        public bool Success;

        [JsonProperty("message")]
        public string Message;

    }



    public class Conyac
    {
        private const string ServiceUrl = "https://biz.conyac.cc/";
        private const string ApiPath = "api/v1/";

        string m_AccessToken;

        private HttpClient m_Client= new HttpClient();
        

        public Conyac(string accessToken)
        {
            m_AccessToken = accessToken;

        }



        public string GetAccessToken(string clientId, string clientSecret, string redirectUri, string accessCode)
        {
            var parameters= new List<KeyValuePair<string, string>>();
            parameters.Add( new KeyValuePair<string, string>("client_id", clientId) );
            parameters.Add( new KeyValuePair<string, string>("client_secret", clientSecret) );
            parameters.Add( new KeyValuePair<string, string>("redirect_uri", redirectUri));
            parameters.Add( new KeyValuePair<string, string>("grant_type", "authorization_code") );
            parameters.Add( new KeyValuePair<string, string>("code", accessCode) );

            var content = m_Client.PostAsync(ServiceUrl + "oauth/token", new FormUrlEncodedContent(parameters)).Result.Content.ReadAsStringAsync().Result;
            JObject result= JObject.Parse(content);

            if (result.Property("error") != null)
            {
                var error= result.Property("error").Value.ToString();
                var desc = result.Property("error_description").Value.ToString();

                throw new Exception(error + " "+ desc);
            }

            return result.Property("access_token").Value.ToString();
        }


        public AccountResult GetAccount()
        {
            var url = new UriBuilder(ServiceUrl + ApiPath+"my");
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var resultStr= m_Client.GetStringAsync(url.Uri).Result;

            var resultObj = new AccountResult();
            resultObj.CallResult = ParseCallResult(resultStr);
            resultObj.Account= JsonConvert.DeserializeObject<Account>(resultStr);

            return resultObj;
        }

        public void CreateProejct(ProjectRequest project)
        {

        }

        public bool CheckProject()
        {

            return true;
        }

        public Project GetProject(int projectId)
        {

            return null;
        }

        public void GetRevisions(int questionId)
        {
            

        }

        public void GetRevision(int questionId, int revisionId)
        {
            
        }




        private CallResult ParseCallResult(string result)
        {
            return JsonConvert.DeserializeObject<CallResult>( result );
        }

        private NameValueCollection GetQueryStringCollection()
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString["access_token"] = m_AccessToken;
            return queryString;
        }






    }

}
