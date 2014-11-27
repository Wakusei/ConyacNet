using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet
{


    public class Account
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("login")]
        public string Login;

        [JsonProperty("created_at")]
        public DateTime CreatedAt;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("locale")]
        public string Locale;
        
        [JsonProperty("picture_url")]
        public string PictureUrl;

        [JsonProperty("translator")]
        public bool Translator;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("default_organization_id")]
        public int DefaultOrganizationId;

        [JsonProperty("default_organization")]
        public Organization DefaultOrganization;
    }

    public class AccountResult
    {
        public CallResult CallResult;

        public Account Account;

    }




}
