// This program exceeds core requirements by:
// 1. Loading scriptures from a file (scriptures.txt)
// 2. Presenting a random scripture each round without repeating
// 3. Only hiding words that are not already hidden
// 4. The ScriptureLibrary class is responsible for loading the scriptures and providing random scriptures
using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        string userChoice = "";

        while (userChoice != "quit" && library.HasScriptures())
        {
            userChoice = RunScripture(library.GetRandomScripture());
        }
    }

    static string RunScripture(Scripture scripture)
    {
        string userChoice = "";

        while (userChoice != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type \"quit\" to finish");
            userChoice = Console.ReadLine();
            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Press enter for a new scripture or type \"quit\" to finish");
        return Console.ReadLine();
    }
}
