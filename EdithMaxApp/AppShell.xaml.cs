namespace EdithMaxApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("gif", typeof(GifPage));
    }
}