using System.Collections.ObjectModel;

namespace GG_Apuntes.Models;

internal class GG_AllApuntes
{
    public ObservableCollection<GG_Notes> Notes { get; set; } = new ObservableCollection<GG_Notes>();

    public GG_AllApuntes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<GG_Notes> notes = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new GG_Notes()
                                    {
                                        Filename = filename,
                                        Text = File.ReadAllText(filename),
                                        Date = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(note => note.Date);

        // Add each note into the ObservableCollection
        foreach (GG_Notes note in notes)
            Notes.Add(note);
    }
}