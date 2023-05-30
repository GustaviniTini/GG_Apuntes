namespace GG_Apuntes.Views;

public partial class GG_AllApuntesPage : ContentPage
{
    public GG_AllApuntesPage()
    {
        InitializeComponent();

        BindingContext = new Models.GG_AllApuntes();
    }

    protected override void OnAppearing()
    {
        ((Models.GG_AllApuntes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(GG_NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.GG_Notes)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(GG_NotePage)}?{nameof(GG_NotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}