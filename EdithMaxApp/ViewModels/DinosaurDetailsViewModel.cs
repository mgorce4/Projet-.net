using CommunityToolkit.Mvvm.ComponentModel;
using EdithMaxApp.Services;
using System.Diagnostics;

namespace EdithMaxApp.ViewModels;

[QueryProperty(nameof(DinosaurId), "id")]
public partial class DinosaurDetailsViewModel : ObservableObject
{
    private readonly IRestasaurusApi _apiService;

    [ObservableProperty]
    private DinosaurResponse? dinosaur;

    [ObservableProperty]
    private bool isLoading = false;

    [ObservableProperty]
    private string? errorMessage;

    private string? _dinosaurId;

    public string? DinosaurId
    {
        get => _dinosaurId;
        set
        {
            if (SetProperty(ref _dinosaurId, value))
            {
                LoadDinosaurDetails();
            }
        }
    }

    public DinosaurDetailsViewModel(IRestasaurusApi apiService)
    {
        _apiService = apiService;
    }

    private async void LoadDinosaurDetails()
    {
        if (string.IsNullOrEmpty(DinosaurId)) return;

        try
        {
            IsLoading = true;
            ErrorMessage = null;
             
            var dinosaur = await _apiService.GetDinosaurByIdAsync(DinosaurId);
            Dinosaur = dinosaur;
            
            if (dinosaur != null)
            {
                Debug.WriteLine($"\n✓ Dinosaure trouvé: {dinosaur.Name}");
                Debug.WriteLine($"├─ Prononciation: {dinosaur.Pronounce}");
                Debug.WriteLine($"├─ Signification: {dinosaur.Meaning}");
                Debug.WriteLine($"├─ Régime: {dinosaur.Diet}");
                Debug.WriteLine($"├─ Période: {dinosaur.Appeared}");
                Debug.WriteLine($"├─ Longueur: {dinosaur.Length}");
                Debug.WriteLine($"├─ Poids: {dinosaur.Weight}");
                
                if (dinosaur.Image != null)
                {
                    Debug.WriteLine($"├─ IMAGE:");
                    Debug.WriteLine($"│  ├─ Titre: {dinosaur.Image.Title}");
                    Debug.WriteLine($"│  ├─ Description: {dinosaur.Image.Description}");
                    Debug.WriteLine($"│  ├─ URL Image: {dinosaur.Image.ImageURL}");
                    Debug.WriteLine($"│  └─ Auteur: {dinosaur.Image.Author}");
                }
                
                Debug.WriteLine("═══════════════════════════════════════════════════════════════\n");
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erreur lors du chargement des détails: {ex.Message}";
            Debug.WriteLine($"ERREUR: {ex.Message}");
            Debug.WriteLine($"Stack Trace: {ex.StackTrace}");
        }
        finally
        {
            IsLoading = false;
        }
    }
}

