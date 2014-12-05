using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConyacNet
{

    public class Revision
    {
        [JsonProperty("revision_number")]
        public int RevisionNumber;

        [JsonProperty("submitted")]
        public bool Submitted;

        [JsonProperty("download_url")]
        public string DownloadUrl;

        [JsonProperty("downloadable")]
        public bool Downloadable;

        [JsonProperty("submitted_at")]
        public DateTime SubmittedAt;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("html_url")]
        public string HtmlUrl;


        [JsonProperty("paragraphs")]
        public List<Paragraph> Paragraphs;

    }


    public class RevisionsResult
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

        [JsonProperty("translation_revisions")]
        public List<Revision> Revisions;

    }


    public class RevisionResult
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

        [JsonProperty("translation")]
        public Revision Translation;

    }



}
