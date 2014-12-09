using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConyacNet.Standard;
using Newtonsoft.Json;

namespace ConyacNet.Simple
{
    public class SimpleTranslation
    {

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("question_id")]
        public int QuestionId;

        [JsonProperty("question_body_id")]
        public int QuestionBodyId;

        [JsonProperty("body")]
        public string Body;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("trainee")]
        public bool Trainee;

        [JsonProperty("posted_at")]
        public DateTime PostedAt;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;
        
        [JsonProperty("comments_count")]
        public int CommentsCount;


    }



    public class SimpleTranslationResult
    {
        public CallResult CallResult;

        [JsonProperty("translation")]
        public SimpleTranslation Translatoin;

    }




}
