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
        public string Name;

        [JsonProperty("plan_id")]
        public int PlanId;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("default")]
        public bool Default;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("html_url")]
        public string HtmlUrl;

        [JsonProperty("point")]
        public int Point;

        [JsonProperty("available_point")]
        public int AvailablePoint;
        
    }

}

