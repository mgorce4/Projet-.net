using EdithMaxApp.ViewModels;
using Microsoft.Maui.Controls;

namespace EdithMaxApp
{
    public partial class FormAddPage : ContentPage
    {
        public FormAddPage()
        {
            InitializeComponent();
            BindingContext = new FormAddViewModel();
        }
    }
}



