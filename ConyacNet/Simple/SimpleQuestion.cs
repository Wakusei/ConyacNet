using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConyacNet.Standard;
using Newtonsoft.Json;

namespace ConyacNet.Simple
{

    public class SimpleQuestion
    {
        [JsonProperty("id")]
        public int Id;
        
        [JsonProperty("description")]
        public string Description;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("organization_id")]
        public int OrganizationId;

        [JsonProperty("LetterCount")]
        public int LetterCount;

        [JsonProperty("PublishedScope")]
        public int PublishedScope;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("status_text")]
        public string StatusText;
        
        [JsonProperty("total_point")]
        public int TotalPoint;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("Url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public string TranslatedLanguageId;

        [JsonProperty("views_count")]
        public int ViewsCount;

        [JsonProperty("published_at")]
        public DateTime PublishedAt;

        [JsonProperty("translated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TranslatedAt;

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt;

        [JsonProperty("translations_count")]
        public int TranslationsCount;

        [JsonProperty("working_translations_count")]
        public int WorkingTranslationsCount;

        [JsonProperty("individual")]
        public bool Individual;

        [JsonProperty("question_bodies")]
        public List<SimpleQuestionBody> QuestionBodies;

        [JsonProperty("language")]
        public Language Language;

        [JsonProperty("translated_language")]
        public Language TranslatedLanguage;

        [JsonProperty("user")]
        public User User;
    }
    
    public class SimpleQuestionRequest
    {

        [JsonProperty("organization_id", NullValueHandling=NullValueHandling.Ignore)]
        public int? OrganizationId;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public string TranslatedLanguageId;

        [JsonProperty("question_bodies")]
        public List<SimpleQuestionBodyRequest> QuestionBodies= new List<SimpleQuestionBodyRequest>();

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("published_scope")]
        [JsonConverter(typeof(SimpleRequestPublicConverter))]
        public bool Public;

        [JsonProperty("escape_text")]
        public int EscapeText;

        [JsonProperty("text_format")]
        public int TextFormat;

        [JsonProperty("tag_text")]
        public string TagText;

        [JsonProperty("access_token")]
        public string AccessToken;
    }


    public class SimpleQuestionCheck
    {
        [JsonProperty("description")]
        public string Description;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("organization_id")]
        public int OrganizationId;

        [JsonProperty("LetterCount")]
        public int LetterCount;

        [JsonProperty("PublishedScope")]
        public int PublishedScope;

        [JsonProperty("status")]
        public int Status;

        [JsonProperty("status_text")]
        public string StatusText;

        [JsonProperty("total_point")]
        public int TotalPoint;
        
        [JsonProperty("Url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public string TranslatedLanguageId;

        [JsonProperty("views_count")]
        public int ViewsCount;

        [JsonProperty("published_at")]
        public DateTime PublishedAt;

        [JsonProperty("expires_at")]
        public DateTime ExpiresAt;

        [JsonProperty("translations_count")]
        public int TranslationsCount;

        [JsonProperty("working_translations_count")]
        public int WorkingTranslationsCount;

        [JsonProperty("individual")]
        public bool Individual;

        [JsonProperty("question_bodies")]
        public List<SimpleQuestionBody> QuestionBodies;

        [JsonProperty("language")]
        public Language Language;

        [JsonProperty("translated_language")]
        public Language TranslatedLanguage;

        [JsonProperty("user")]
        public User User;
    }


    public class SimpleQuestionBodyRequest
    {

        [JsonProperty("body")]
        public string Body;


    }
    

    public class SimpleQuestionResult
    {
        public CallResult CallResult;

        [JsonProperty("question")]
        public SimpleQuestion Question;

    }

    public class SimpleQuestionCheckResult
    {
        public CallResult CallResult;

        [JsonProperty("question")]
        public SimpleQuestionCheck Question;

    }



    class SimpleRequestPublicConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var casted = (bool)value;

            writer.WriteValue(casted ? 0 : 2);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


}
