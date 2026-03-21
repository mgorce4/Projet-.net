using EdithMaxApp.ViewModels;

namespace EdithMaxApp;

public partial class DinosaurImageDetailPage : ContentPage
{
    public DinosaurImageDetailPage(DinosaurImageDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

