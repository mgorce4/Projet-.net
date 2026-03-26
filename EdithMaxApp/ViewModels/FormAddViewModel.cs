using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace EdithMaxApp.ViewModels;

public partial class FormAddViewModel : ObservableObject
{
    [ObservableProperty]
    public string titre = string.Empty;

    [ObservableProperty]
    public string description = string.Empty;

    [ObservableProperty]
    public string imageUri = string.Empty;

    [ObservableProperty]
    public string titrErreur = string.Empty;

    [ObservableProperty]
    public string descriptionErreur = string.Empty;

    [ObservableProperty]
    public string imageErreur = string.Empty;

    [ObservableProperty]
    public bool estImageSelectionnee;

    [RelayCommand]
    public async Task ChoisirImageGalerie()
    {
        try
        {
            // Effacer les messages d'erreur précédents
            ImageErreur = string.Empty;

            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Choisir une image"
            });

            if (result != null)
            {
                // Copier l'image au cache pour pouvoir l'afficher
                var newFile = Path.Combine(FileSystem.CacheDirectory, result.FileName);
                using (var stream = await result.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                ImageUri = newFile;
                EstImageSelectionnee = true;
                Debug.WriteLine($"✅ Image sélectionnée: {ImageUri}");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"❌ Erreur galerie: {ex.Message}");
            ImageErreur = "Erreur lors du choix de l'image";
        }
    }

    [RelayCommand]
    public async Task PrendrePhoto()
    {
        try
        {
            // Effacer les messages d'erreur précédents
            ImageErreur = string.Empty;

            if (!MediaPicker.Default.IsCaptureSupported)
            {
                ImageErreur = "Appareil photo non disponible";
                Debug.WriteLine("❌ Appareil photo non disponible");
                return;
            }

            var photo = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
            {
                Title = "Prendre une photo"
            });

            if (photo != null)
            {
                // Copier la photo au cache pour pouvoir l'afficher
                var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                ImageUri = newFile;
                EstImageSelectionnee = true;
                Debug.WriteLine($"✅ Photo prise: {ImageUri}");
            }
            else
            {
                Debug.WriteLine("❌ Photo annulée par l'utilisateur");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"❌ Erreur appareil photo: {ex.Message}");
            ImageErreur = "Erreur lors de la prise de photo";
        }
    }

    [RelayCommand]
    public async Task Sauvegarder()
    {
        // Réinitialiser les erreurs
        TitrErreur = string.Empty;
        DescriptionErreur = string.Empty;
        ImageErreur = string.Empty;

        bool estValide = true;

        // Validation du titre
        if (string.IsNullOrWhiteSpace(Titre))
        {
            TitrErreur = "Le titre est requis";
            estValide = false;
        }

        // Validation de la description
        if (string.IsNullOrWhiteSpace(Description))
        {
            DescriptionErreur = "La description est requise";
            estValide = false;
        }

        // Validation de l'image
        if (string.IsNullOrWhiteSpace(ImageUri))
        {
            ImageErreur = "Veuillez sélectionner une image";
            estValide = false;
        }

        // Si tout est valide
        if (estValide)
        {
            await Application.Current?.MainPage?.DisplayAlert(
                "✅ Succès",
                $"Dinosaure ajouté!\n\nTitre: {Titre}\nDescription: {Description}\nImage: {ImageUri}",
                "OK"
            );

            // Réinitialiser les champs
            ResetForm();
        }
    }

    private void ResetForm()
    {
        Titre = string.Empty;
        Description = string.Empty;
        ImageUri = string.Empty;
        EstImageSelectionnee = false;
        TitrErreur = string.Empty;
        DescriptionErreur = string.Empty;
        ImageErreur = string.Empty;
    }
}

