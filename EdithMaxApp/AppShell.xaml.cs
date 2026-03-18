namespace EdithMaxApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        // Enregistrement des routes pour pouvoir naviguer vers les pages Tab
        Routing.RegisterRoute("gifpage", typeof(GifPage));
        Routing.RegisterRoute("homepage", typeof(HomePage));
    }
}