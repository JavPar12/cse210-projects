using System;

// CREATIVITY AND EXCEEDING REQUIREMENTS:
// 1. In the ReflectingActivity, I implemented a 'Unique Question' logic. 
//    The program tracks which questions have already been shown in the current session
//    and ensures that no question is repeated until the entire list has been exhausted.
// 2. In the ListingActivity, I added a validation to ensure that empty inputs 
//    are not counted toward the final total of items listed.

class Program
{
    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
        }
    }
}