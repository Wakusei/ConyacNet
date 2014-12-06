using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet.Standard
{

    public class Language
    {
        [JsonProperty("id")]
        public string Id;
        
        [JsonProperty("localized_name")]
        public string LocalizedName;

    }

}
