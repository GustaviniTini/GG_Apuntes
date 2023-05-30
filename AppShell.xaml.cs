namespace GG_Apuntes;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(Views.GG_NotePage), typeof(Views.GG_NotePage));
    }
}