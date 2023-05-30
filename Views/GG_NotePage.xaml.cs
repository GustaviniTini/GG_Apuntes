

namespace GG_Apuntes.Views;


[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class GG_NotePage : ContentPage

{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "GG_notes.txt");

    public GG_NotePage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));

    }

    private void LoadNote(string fileName)
    {
        Models.GG_Notes noteModel = new Models.GG_Notes();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }



    private async void GG_SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.GG_Notes note)
            File.WriteAllText(note.Filename, GG_TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void GG_DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.GG_Notes note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }


    

        public string ItemId
    {
        set { LoadNote(value); }
    }
}