// This program exceeds the core requirements by saving and loading
// the journal in JSON format instead of a plain text file,
// and by merging existing entries when saving to an existing file.
using System;
class Program
{
    static void Main(string[] args)
    {
        static void DisplayMenu()
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            List<string> options = new List<string>()
                                        {
                                            "1. Write",
                                            "2. Display",
                                            "3. Load",
                                            "4. Save",
                                            "5. Quit"
                                        };
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }
        }

        Journal newJournal = new Journal();
        int option = 0;
        while (option != 5)
        {
            DisplayMenu();
            Console.Write("What would you like to do? ");
            try
            {
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    PromptGenerator newPrompt = new PromptGenerator();
                    string promptSelected = newPrompt.GetRandomPrompt();
                    Console.WriteLine(promptSelected);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._prompt = promptSelected;
                    entry._entry = response;
                    newJournal.AddEntry(entry);

                }
                else if (option == 2)
                {
                    newJournal.DisplayAll();
                }
                else if (option == 3)
                {
                    Console.Write("Please enter the name of the file: ");
                    string filename = Console.ReadLine();
                    newJournal.LoadFromFile(filename);
                }
                else if (option == 4)
                {
                    Console.Write("Please enter the name of the file: ");
                    string filename = Console.ReadLine();
                    newJournal.SaveToFile(filename);
                }
                else if (option > 5 || option <= 0)
                {
                    Console.WriteLine("Please enter only the numbers that are in the menu");
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Please enter only the numbers that are in the menu");
                Console.WriteLine("Don't input letters");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("That file doesn't exists please enter the correct file name!");
            }
        }
    }
}
