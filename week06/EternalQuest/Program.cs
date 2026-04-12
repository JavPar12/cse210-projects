using System;

/*
CREATIVITY AND EXCEEDING REQUIREMENTS:
1. Leveling System: I implemented a dynamic leveling system in the GoalManager. 
The user's level is calculated and displayed based on their total score 
(Level = Score / 1000 + 1).
2. Advanced File Handling: The LoadGoals method includes specialized logic to 
reconstruct ChecklistGoal objects, ensuring the current completion count 
is accurately restored from the saved file.
3. Enhanced UI: Added visual separators and clear status messages to improve 
the user experience and make the gamification feel more engaging.
*/

class Program
{
    static void Main(string[] args)
    {
        // Initialize the brain of the program
        GoalManager manager = new GoalManager();
        
        // Start the main menu loop
        manager.Start();
    }
}