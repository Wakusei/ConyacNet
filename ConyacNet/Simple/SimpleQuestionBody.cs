using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet.Simple
{
    public class SimpleQuestionBody
    {
        [JsonProperty("id")]
        public int Id;
            
        [JsonProperty("question_id")]
        public int QuestionId;

        [JsonProperty("display_order")]
        public string DisplayOrder;

        [JsonProperty("body")]
        public string Body;

        [JsonProperty("letter_count")]
        public string LetterCount;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        
        [JsonProperty("url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl; 

        [JsonProperty("translated_at")]
        public DateTime? TranslatedAt;
        
        [JsonProperty("translations")]
        public List<SimpleTranslation> Translations;

    }
}
