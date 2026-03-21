using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EdithMaxApp.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;
using EdithMaxApp.Models;

namespace EdithMaxApp.ViewModels;

public partial class GalleryViewModel : ObservableObject
{
    private readonly IRestasaurusApi _apiService;

    [ObservableProperty]
    private ObservableCollection<DinosaurImageItemViewModel> dinosaurImages = new();

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string? errorMessage;

    public GalleryViewModel(IRestasaurusApi apiService)
    {
        _apiService = apiService;
    }

    [RelayCommand]
    public async Task LoadImages()
    {
        try
        {
            IsLoading = true;
            ErrorMessage = null;

            var result = await _apiService.GetRandomImagesAsync(10);
            
            DinosaurImages.Clear();
            if (result?.Data != null)
            {
                foreach (var wrapper in result.Data)
                {
                    if (wrapper?.Image != null)
                    {
                        DinosaurImages.Add(new DinosaurImageItemViewModel(wrapper.Image));
                        Debug.WriteLine($"✅ Image ajoutée: {wrapper.Image.Title}");
                    }
                }
            }

            Debug.WriteLine($"✅ Total: {DinosaurImages.Count} images chargées");
        }
        catch (Exception ex)
        {
            ErrorMessage = $"Erreur: {ex.Message}";
            Debug.WriteLine($"❌ ERREUR LoadImages: {ex.Message}\n{ex.StackTrace}");
        }
        finally
        {
            IsLoading = false;
        }
    }
}

/// <summary>
/// ViewModel pour une image dans la galerie.
/// Gère l'état d'affichage/masquage de la description.
/// </summary>
public partial class DinosaurImageItemViewModel : ObservableObject
{
    [ObservableProperty]
    private DinosaurImage image;

    [ObservableProperty]
    private bool isDescriptionVisible;

    public DinosaurImageItemViewModel(DinosaurImage image)
    {
        Image = image;
        IsDescriptionVisible = false;
    }

    [RelayCommand]
    public void ToggleDescription()
    {
        IsDescriptionVisible = !IsDescriptionVisible;
        Debug.WriteLine($"📝 Description toggle: {IsDescriptionVisible} pour {Image.Title}");
    }
}
