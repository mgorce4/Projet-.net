using Refit;

namespace EdithMaxApp.Services;

public interface IRestasaurusApi
{
    [Get("/api/v1/dinosaurs/random/image")]
    Task<DinosaurImageResponse> GetRandomDinosaurImageAsync();

    [Get("/api/v1/dinosaurs")]
    Task<List<DinosaurResponse>> GetDinosaursAsync();

    [Get("/api/v1/dinosaurs/{id}")]
    Task<DinosaurResponse> GetDinosaurByIdAsync(string id);
}

public class DinosaurImageResponse
{
    [AliasAs("image")]
    public string? Image { get; set; }

    [AliasAs("dinosaur")]
    public string? Dinosaur { get; set; }
}

public class DinosaurResponse
{
    [AliasAs("_id")]
    public string? Id { get; set; }

    [AliasAs("name")]
    public string? Name { get; set; }

    [AliasAs("pronounce")]
    public string? Pronounce { get; set; }

    [AliasAs("meaning")]
    public string? Meaning { get; set; }

    [AliasAs("diet")]
    public string? Diet { get; set; }

    [AliasAs("appeared")]
    public string? Appeared { get; set; }

    [AliasAs("length")]
    public string? Length { get; set; }

    [AliasAs("weight")]
    public string? Weight { get; set; }

    [AliasAs("image")]
    public string? Image { get; set; }
}

