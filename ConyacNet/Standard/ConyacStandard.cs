using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConyacNet.Standard
{




    public class ConyacStandard : ConyacBase
    {
        private const string ApiPath = "api/v1/";

        
        

        public ConyacStandard(string accessToken, bool useDevelopment= false)
        {
            m_AccessToken = accessToken;
            m_UseDevelopmentService = useDevelopment;
        }





        public async Task<string> GetAccessToken(string clientId, string clientSecret, string redirectUri, string accessCode)
        {
            var parameters= new List<KeyValuePair<string, string>>();
            parameters.Add( new KeyValuePair<string, string>("client_id", clientId) );
            parameters.Add( new KeyValuePair<string, string>("client_secret", clientSecret) );
            parameters.Add( new KeyValuePair<string, string>("redirect_uri", redirectUri));
            parameters.Add( new KeyValuePair<string, string>("grant_type", "authorization_code") );
            parameters.Add( new KeyValuePair<string, string>("code", accessCode) );

            var response= await m_Client.PostAsync(ServiceUrl + "oauth/token", new FormUrlEncodedContent(parameters));
            var content = await response.Content.ReadAsStringAsync();
            JObject result= JObject.Parse(content);

            if (result.Property("error") != null)
            {
                var error= result.Property("error").Value.ToString();
                var desc = result.Property("error_description").Value.ToString();

                throw new Exception(error + " "+ desc);
            }

            return result.Property("access_token").Value.ToString();
        }


        public async Task<AccountResult> GetAccount()
        {
            var url = new UriBuilder(ServiceUrl + ApiPath+"my");
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response= await m_Client.GetStringAsync(url.Uri);

            var resultObj = new AccountResult();
            resultObj.CallResult = ParseCallResult(response);
            resultObj.User= JsonConvert.DeserializeObject<User>(response);

            return resultObj;
        }

        public async Task<ProjectResult> CreateProject(ProjectRequest project)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "projects");
            project.AccessToken = m_AccessToken;
            
            var response= await PostJson(url.Uri, JsonConvert.SerializeObject(project));

            var resultObj =  JsonConvert.DeserializeObject<ProjectResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<ProjectResult> CheckProject(ProjectRequest project)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "projects/check");
            project.AccessToken = m_AccessToken;

            var response = await PostJson(url.Uri, JsonConvert.SerializeObject(project));

            var resultObj = JsonConvert.DeserializeObject<ProjectResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<ProjectResult> GetProject(int projectId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "projects/"+projectId.ToString(CultureInfo.InvariantCulture) );
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<ProjectResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<RevisionsResult> GetRevisions(int questionId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + string.Format(CultureInfo.InvariantCulture, "questions/{0}/revisions/", questionId));
                
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<RevisionsResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<RevisionResult> GetRevision(int questionId, int revisionId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath +
                string.Format(CultureInfo.InvariantCulture, "questions/{0}/revisions/{1}", questionId, revisionId));

            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<RevisionResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }



        public async Task<ApplicatoinEventsResult> GetApplicationEvents(int since, bool ascendance)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "my/application_events");
            var queryString = GetQueryStringCollection();
            queryString["since"] = since.ToString(CultureInfo.InvariantCulture);
            if (ascendance)
            {
                queryString["order"] = "id_asc";
            }
            else
            {
                queryString["order"] = "id_desc";
            }
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<ApplicatoinEventsResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<ApplicatoinEventResult> GetApplicationEvent(int id)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "my/application_events/" + id.ToString(CultureInfo.InvariantCulture));
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<ApplicatoinEventResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }




    }

}
