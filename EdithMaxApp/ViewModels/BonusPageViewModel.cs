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
    private DinosaurImage? randomDinosaur;

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

            // Charger aussi un dinosaure aléatoire
            await LoadNewRandomDinosaur();
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

    [RelayCommand]
    public async Task LoadNewRandomDinosaur()
    {
        try
        {
            // Charger 1 dinosaure aléatoire
            var result = await _apiService.GetRandomImagesAsync(1);
            
            if (result?.Data?.FirstOrDefault()?.Image != null)
            {
                RandomDinosaur = result.Data.First().Image;
                Debug.WriteLine($"Dinosaure aléatoire chargé: {RandomDinosaur.Title}");
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erreur lors du chargement du dinosaure aléatoire: {ex.Message}";
            Debug.WriteLine($"ERREUR LoadNewRandomDinosaur: {ex.Message}\n{ex.StackTrace}");
        }
    }
}

