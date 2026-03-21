namespace EdithMaxApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("gifpage", typeof(GifPage));
        Routing.RegisterRoute("homepage", typeof(HomePage));
        Routing.RegisterRoute(nameof(GalleryPage), typeof(GalleryPage));
    }
}