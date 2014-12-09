using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet.Standard
{
    public enum QuestionType
    {
        String,
        TextHtml,
        File
    }


    public class Question
    {
        
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("project_id")]
        public int ProjectId;
        
        [JsonProperty("user_id")]
        public int UserId;
        
        [JsonProperty("letter_count")]
        public int LetterCount;
 
        [JsonProperty("status")]
        public int Status;
        
        [JsonProperty("total_point")]
        public int TotalPoint;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("language_id")]
        public string LanguageId;

        [JsonProperty("translated_language_id")]
        public string TranslatedLanguageId;

        [JsonProperty("paragraphs")]
        public string Paragraphs;

        [JsonProperty("language")]
        public Language Language;

        [JsonProperty("translated_language")]
        public Language TranslatedLanguage;

    }

    public class QuestionRequest
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(QuestionTypeConverter))]
        public QuestionType Type;
        
        [JsonProperty("escape_text")]
        public int EscapeText;

        [JsonProperty("source_id", NullValueHandling=NullValueHandling.Ignore)]
        public int? SourceId;

        [JsonProperty("body")]
        public string Body;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("double_check")]
        public int DoubleCheck;

        [JsonProperty("custom_field")]
        public List<string> CustomFields;

        [JsonProperty("individual")]
        public int Individual;

        [JsonProperty("translator_list_ids")]
        public List<int> TranslatorListIds;

    }


    class QuestionTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var type = (QuestionType) value;

            switch (type)
            {
                case QuestionType.File:
                    writer.WriteValue("file");
                    break;
                case QuestionType.TextHtml:
                    writer.WriteValue("text_html");
                    break;
                case QuestionType.String:
                    writer.WriteValue("string");
                    break;
            }

        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (QuestionType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }



}
