using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet
{

    public class Paragraph
    {

        [JsonProperty("id")]
        public int Id;

        [JsonProperty("paragraph_id")]
        public int ParagraphId;

        [JsonProperty("section_id")]
        public int SectionId;

        [JsonProperty("display_order")]
        public int DisplayOrder;

        [JsonProperty("original_text")]
        public string OriginalText;

        [JsonProperty("translated_text")]
        public string TranslatedText;

        [JsonProperty("updated_by")]
        public int UpdatedBy;

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt;

        [JsonProperty("revision_number")]
        public int RevisionNumber;


    }

}
