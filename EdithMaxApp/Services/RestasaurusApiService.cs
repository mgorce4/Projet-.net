using Refit;

namespace EdithMaxApp.Services;

public class RestasaurusApiService
{
    private readonly IRestasaurusApi _api;

    public RestasaurusApiService()
    {
        _api = RestClient.For<IRestasaurusApi>("https://restasaurus.herokuapp.com");
    }

    public async Task<DinosaurImageResponse?> GetRandomDinosaurImageAsync()
    {
        try
        {
            return await _api.GetRandomDinosaurImageAsync();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erreur: {ex.Message}");
            return null;
        }
    }

    public async Task<List<DinosaurResponse>?> GetDinosaursAsync()
    {
        try
        {
            return await _api.GetDinosaursAsync();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erreur: {ex.Message}");
            return null;
        }
    }

    public async Task<DinosaurResponse?> GetDinosaurByIdAsync(string id)
    {
        try
        {
            return await _api.GetDinosaurByIdAsync(id);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Erreur: {ex.Message}");
            return null;
        }
    }
}

