using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EdithMaxApp.Models;
using EdithMaxApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace EdithMaxApp.ViewModels;

public partial class BonusPageViewModel : ObservableObject
{
    private readonly IRestasaurusApi _apiService;

    [ObservableProperty]
    private ObservableCollection<DinosaurImage> dinosaurImages = new();

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string? errorMessage;

    public BonusPageViewModel(IRestasaurusApi apiService)
    {
        _apiService = apiService;
    }

    [RelayCommand]
    public async Task LoadRandomDinosaurs()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = null;

            DinosaurImages.Clear();

            // Charger 5 images aléatoires de l'API
            var result = await _apiService.GetRandomImagesAsync(5);
            
            if (result?.Data != null)
            {
                foreach (var wrapper in result.Data)
                {
                    if (wrapper?.Image != null)
                    {
                        DinosaurImages.Add(wrapper.Image);
                        Debug.WriteLine($"Image carrousel ajoutée: {wrapper.Image.Title}");
                    }
                }
            }

            Debug.WriteLine($"Total: {DinosaurImages.Count} images chargées dans le carrousel");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erreur: {ex.Message}";
            Debug.WriteLine($"ERREUR LoadRandomDinosaurs: {ex.Message}\n{ex.StackTrace}");
        }
        finally
        {
            IsLoading = false;
        }
    }
}

