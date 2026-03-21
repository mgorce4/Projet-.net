using Refit;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EdithMaxApp.Services
{
    public interface IRestasaurusApi
    {
        [Get("/api/v1/dinosaurs/{id}")]
        Task<DinosaurResponse> GetDinosaurByIdAsync(string id);

        [Get("/api/v1/dinosaurs/image")]
        Task<DinosaurImageResponse> GetRandomDinosaurImageAsync();
        
        [Get("/api/v1/dinosaurs")]
        Task<List<DinosaurResponse>> GetDinosaursAsync();

        [Get("/api/v1/images/random/{count}")]
        Task<EdithMaxApp.Models.DinosaurImagesApiResponse> GetRandomImagesAsync(int count);
    }

    public class DinosaurResponse
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("pronounce")]
        public string Pronounce { get; set; }

        [JsonPropertyName("meaning")]
        public string Meaning { get; set; }

        [JsonPropertyName("diet")]
        public string Diet { get; set; }

        [JsonPropertyName("appeared")]
        public string Appeared { get; set; }

        [JsonPropertyName("length")]
        public string Length { get; set; }

        [JsonPropertyName("weight")]
        public string Weight { get; set; }

        [JsonPropertyName("image")]
        public ImageData Image { get; set; }
    }

    public class DinosaurImageResponse
    {
        [JsonPropertyName("image")]
        public ImageData Image { get; set; }

        [JsonPropertyName("dinosaur")]
        public string Dinosaur { get; set; }
    }

    public class ImageData
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("authorURL")]
        public string AuthorURL { get; set; }

        [JsonPropertyName("imageURL")]
        public string ImageURL { get; set; }

        [JsonPropertyName("license")]
        public string License { get; set; }

        [JsonPropertyName("licenseURL")]
        public string LicenseURL { get; set; }

        [JsonPropertyName("dateCreated")]
        public string DateCreated { get; set; }

        [JsonPropertyName("dateAccessed")]
        public string DateAccessed { get; set; }
    }
}
