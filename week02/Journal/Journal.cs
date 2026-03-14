using System;
using System.Text.Json;
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to display, please write an entry first");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }

    public void LoadFromFile(string filename)
    {
        string jsonFilename = filename + ".json";

        if (!File.Exists(jsonFilename))
        {
            Console.WriteLine($"The file {jsonFilename} does not exist, please try again");
            return;
        }
        else
        {
            string jsonString = File.ReadAllText(jsonFilename);
            _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString, new JsonSerializerOptions { IncludeFields = true });
            Console.WriteLine($"Your journal has been loaded from {jsonFilename}");
        }

    }

    public void SaveToFile(string filename)
    {
        string jsonFilename = filename + ".json";

        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries to save, please write an entry first");
            return;
        }
        else if (File.Exists(jsonFilename))
        {
            Console.WriteLine($"The file {jsonFilename} already exists, do you want to load the existing entries and merge them? (y/n)");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                string existingJson = File.ReadAllText(jsonFilename);
                var options = new JsonSerializerOptions { IncludeFields = true };
                List<Entry> existingEntries = JsonSerializer.Deserialize<List<Entry>>(existingJson, options);

                foreach (Entry entry in existingEntries)
                {
                    if (!_entries.Any(e => e._date == entry._date && e._prompt == entry._prompt))
                    {
                        _entries.Add(entry);
                    }
                }

                Console.WriteLine("Entries combined and saved to file.");
            }
            else
            {
                Console.WriteLine("The existing file will be overwritten.");
            }
        }

        string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
        File.WriteAllText(jsonFilename, jsonString);
        Console.WriteLine($"Your journal has been saved to {jsonFilename}");
    }
}
