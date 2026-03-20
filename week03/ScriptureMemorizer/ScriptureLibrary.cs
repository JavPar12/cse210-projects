using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary(string filename)
    {
        _scriptures = new List<Scripture>();
        LoadScriptures(filename);
    }

    private void LoadScriptures(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string reference = parts[0];
            string text = parts[1];

            Reference newReference = GetReference(reference);
            Scripture newScripture = new Scripture(newReference, text);
            _scriptures.Add(newScripture);
        }
    }

    private Reference GetReference(string reference)
    {
        string[] parts = reference.Split(':');
        string[] bookAndChapter = parts[0].Split(' ');
        int chapter = int.Parse(bookAndChapter[bookAndChapter.Length - 1]);
        string book = string.Join(' ', bookAndChapter, 0, bookAndChapter.Length - 1);
        string verses = parts[1];

        if (verses.Contains('-'))
        {
            string[] verseParts = verses.Split('-');
            int startVerse = int.Parse(verseParts[0]);
            int endVerse = int.Parse(verseParts[1]);
            return new Reference(book, chapter, startVerse, endVerse);

        }
        else
        {
            int verse = int.Parse(verses);
            return new Reference(book, chapter, verse);
        }
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        Scripture scripture = _scriptures[index];
        _scriptures.RemoveAt(index);
        return scripture;
    }

    public bool HasScriptures()
    {
        return _scriptures.Count > 0;
    }
}
