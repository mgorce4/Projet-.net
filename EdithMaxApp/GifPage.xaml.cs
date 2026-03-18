using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdithMaxApp;

public partial class GifPage : ContentPage
{
    public GifPage()
    {
        InitializeComponent();
    }

    private async void OnBackToHomeClicked(object sender, EventArgs e)
    {
        // Navigation Shell recommandée - utilise la route enregistrée
        await Shell.Current.GoToAsync("homepage");
    }
}