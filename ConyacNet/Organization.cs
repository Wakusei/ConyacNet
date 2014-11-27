using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet
{

    public class Organization
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public bool Name;

        [JsonProperty("plan_id")]
        public bool PlanId;

        [JsonProperty("user_id")]
        public bool UserId;

        [JsonProperty("default")]
        public int Default;

        [JsonProperty("description")]
        public bool Description;

        [JsonProperty("created_at")]
        public bool CreatedAt;

        [JsonProperty("updated_at")]
        public bool UpdatedAt;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("point")]
        public bool Point;

        [JsonProperty("available_point")]
        public bool AvailablePoint;
        
    }

}

