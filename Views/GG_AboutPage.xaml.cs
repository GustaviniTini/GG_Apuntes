namespace GG_Apuntes.Views;

public partial class GG_AboutPage : ContentPage
{
	public GG_AboutPage()
	{
		InitializeComponent();
	}

    private async void GG_LearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.GG_About about)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync(about.MoreInfoUrl);
        }
    }

   
}