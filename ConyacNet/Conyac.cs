using System;
using System.Collections.Generic;
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


        string m_AccessToken;

        private HttpClient m_Client= new HttpClient();
        

        public Conyac(string accessToken)
        {
            m_AccessToken = accessToken;

        }



        public string GetAccessToken(string clientId, string clientSecret, string accessCode)
        {
            var parameters= new List<KeyValuePair<string, string>>();
            parameters.Add( new KeyValuePair<string, string>("client_id", clientId) );
            parameters.Add( new KeyValuePair<string, string>("client_secret", clientSecret) );
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

            

            return "";
        }


        public AccountResult GetAccount()
        {





            return null;
        }


        public void CreateProejct()
        {
            
        }



    }

}
