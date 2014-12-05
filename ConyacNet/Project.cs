using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConyacNet
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("organization_id")]
        public int OrganizationId;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("point")]
        public int Point;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public int UpdatedAt;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public int TranslatedLanguageId;

        [JsonProperty("individual")]
        public bool Individual;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("html_url")]
        public int HtmlUrl;

        [JsonProperty("organization")]
        public Organization Organization;

        [JsonProperty("questions")]
        public List<Question> Questions;



        [JsonProperty("language")]
        public Language Language;

        [JsonProperty("translated_language")]
        public Language TranslatedLanguage;
        
    }


    public class ProjectRequest
    {
        [JsonProperty("organization_id")]
        public int OrganizationId;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public string TranslatedLanguageId;

        [JsonProperty("questions")]
        public List<QuestionRequest> Questions= new List<QuestionRequest>();

        [JsonProperty("access_token")]
        public string AccessToken;

    }


    public class ProjectResult
    {
        public CallResult CallResult;

        [JsonProperty("project")]
        public Project Project;


    }



}
