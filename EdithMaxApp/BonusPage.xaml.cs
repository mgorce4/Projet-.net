using EdithMaxApp.ViewModels;

namespace EdithMaxApp;

public partial class BonusPage : ContentPage
{
    public BonusPage(BonusPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        
        if (BindingContext is BonusPageViewModel viewModel)
        {
            await viewModel.LoadRandomDinosaursCommand.ExecuteAsync(null);
        }
    }
}


