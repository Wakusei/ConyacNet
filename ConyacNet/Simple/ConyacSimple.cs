using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConyacNet.Standard;
using Newtonsoft.Json;

namespace ConyacNet.Simple
{

    public class ConyacSimple : ConyacBase
    {

        private const string ApiPath = "api/v1/simple/";




        public ConyacSimple(string accessToken, bool useDevelopment = false)
        {
            m_AccessToken = accessToken;
            m_UseDevelopmentService = useDevelopment;
        }


        public async Task<SimpleQuestionResult> CreateProject(SimpleQuestionRequest project)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "questions");
            project.AccessToken = m_AccessToken;

            var response = await PostJson(url.Uri, JsonConvert.SerializeObject(project));

            var resultObj = JsonConvert.DeserializeObject<SimpleQuestionResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<SimpleQuestionResult> CheckProject(ProjectRequest project)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "projects/check");
            project.AccessToken = m_AccessToken;

            var response = await PostJson(url.Uri, JsonConvert.SerializeObject(project));

            var resultObj = JsonConvert.DeserializeObject<SimpleQuestionResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<SimpleQuestionResult> GetQuestion(int questionId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath + "questions/" + questionId.ToString(CultureInfo.InvariantCulture));
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<SimpleQuestionResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<SimpleQuestionResult> CancelQuestion(int questionId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath +
                string.Format(CultureInfo.InvariantCulture, "questions/{0}/cancel", questionId ) );
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<SimpleQuestionResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }

        public async Task<SimpleTranslationResult> GetTranslation(int translationId)
        {
            var url = new UriBuilder(ServiceUrl + ApiPath +
                string.Format(CultureInfo.InvariantCulture, "translations/{0}", translationId));
            var queryString = GetQueryStringCollection();
            url.Query = queryString.ToString();

            var response = await m_Client.GetStringAsync(url.Uri);

            var resultObj = JsonConvert.DeserializeObject<SimpleTranslationResult>(response);
            resultObj.CallResult = ParseCallResult(response);

            return resultObj;
        }






    }


}
