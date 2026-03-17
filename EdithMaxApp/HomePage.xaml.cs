using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Views;

namespace EdithMaxApp
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                if (mediaElement != null)
                {
                    await LoadVideoAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur vidéo: {ex.Message}");
            }
        }

        private async Task LoadVideoAsync()
        {
            try
            {
                // Chemin vers le dossier des vidéos
                string videoDir = Path.Combine(FileSystem.AppDataDirectory, "video");
                string videoPath = Path.Combine(videoDir, "video.mp4");

                // Créer le répertoire s'il n'existe pas
                if (!Directory.Exists(videoDir))
                    Directory.CreateDirectory(videoDir);

                // Vérifier si la vidéo existe déjà, sinon la copier
                if (!File.Exists(videoPath))
                {
                    // Essayer de copier depuis les ressources
                    using (var stream = await FileSystem.OpenAppPackageFileAsync("video/video.mp4"))
                    {
                        using (var fileStream = File.Create(videoPath))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                }

                // Définir la source avec le chemin complet
                mediaElement.Source = videoPath;
                System.Diagnostics.Debug.WriteLine($"Source définie à: {videoPath}");
                System.Diagnostics.Debug.WriteLine($"Fichier existe: {File.Exists(videoPath)}");

                await Task.Delay(500);
                mediaElement.Play();
                System.Diagnostics.Debug.WriteLine("Vidéo lancée");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur lors du chargement vidéo: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }

        private async void OnDiscoverDinosClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("gif");
        }
    }
}
