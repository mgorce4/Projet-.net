using EdithMaxApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EdithMaxApp.ViewModels
{
    public partial class DinosaurImageDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private DinosaurImage? dinosaurImage;

        public DinosaurImageDetailViewModel(DinosaurImage? image)
        {
            DinosaurImage = image ?? new DinosaurImage {
                Title = "Inconnu",
                Description = "Aucune description disponible.",
                Author = "?",
                AuthorURL = string.Empty,
                ImageURL = string.Empty,
                License = string.Empty,
                LicenseURL = string.Empty,
                DateCreated = string.Empty,
                DateAccessed = string.Empty
            };
        }
    }
}

