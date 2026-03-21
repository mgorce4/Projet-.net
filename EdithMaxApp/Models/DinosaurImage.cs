using Newtonsoft.Json;

namespace EdithMaxApp.Models
{
    public class DinosaurImage
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("authorURL")]
        public string AuthorURL { get; set; }

        [JsonProperty("imageURL")]
        public string ImageURL { get; set; }

        [JsonProperty("license")]
        public string License { get; set; }

        [JsonProperty("licenseURL")]
        public string LicenseURL { get; set; }

        [JsonProperty("dateCreated")]
        public string DateCreated { get; set; }

        [JsonProperty("dateAccessed")]
        public string DateAccessed { get; set; }
    }

    public class DinosaurImageWrapper
    {
        [JsonProperty("image")]
        public DinosaurImage Image { get; set; }

        [JsonProperty("dinosaur")]
        public string Dinosaur { get; set; }
    }

    public class DinosaurImagesApiResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("data")]
        public List<DinosaurImageWrapper> Data { get; set; }
    }
}
