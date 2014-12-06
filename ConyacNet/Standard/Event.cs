using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet.Standard
{
    public class ApplicatoinEvent
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("action_user_id")]
        public int ActionUserId;

        [JsonProperty("application_id")]
        public int ApplicationId;

        [JsonProperty("organization_id")]
        public int OrganizationId;

        [JsonProperty("action_organization_id")]
        public int ActionOrganizationId;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("retry_count")]
        public int RetryCount;


        [JsonProperty("question")]
        public Question Question;

    }



    public class ApplicatoinEventsResult
    {
        public CallResult CallResult;


        [JsonProperty("page")]
        public int Page;

        [JsonProperty("per_page")]
        public int PerPage;

        [JsonProperty("total_pages")]
        public int TotalPages;

        [JsonProperty("total_count")]
        public int TotalCount;
        
        [JsonProperty("events")]
        public List<ApplicatoinEvent> Events;
        
    } 
    
    public class ApplicatoinEventResult
    {
        public CallResult CallResult;


        [JsonProperty("event")]
        public ApplicatoinEvent Event;
    }



}
