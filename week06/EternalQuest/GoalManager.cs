using System;
using System.Collections.Generic;
using System.IO;

// Main class to manage the flow of the Eternal Quest program
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main loop that displays the menu and handles user choices
    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
        }
    }

    // Displays the score and the calculated Level (Creativity requirement)
    public void DisplayPlayerInfo()
    {
        int level = (_score / 1000) + 1;
        Console.WriteLine($"\n>>> Current Score: {_score} | Level: {level} <<<");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            string status = _goals[i].IsComplete() ? "X" : " ";
            Console.WriteLine($"{i + 1}. [{status}] {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
{
    ListGoalNames();
    Console.Write("Which goal did you accomplish? ");
    string input = Console.ReadLine();

    // int.TryParse returns true if it's a number, and false if it's text
    if (int.TryParse(input, out int index))
    {
        index = index - 1; // Adjust for zero-based index

        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            
            string representation = _goals[index].GetStringRepresentation();
            string[] parts = representation.Split(':')[1].Split(',');
            int pointsEarned = int.Parse(parts[2]);

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You earned {pointsEarned} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection. That goal number does not exist.");
        }
    }
    else
    {
        // This prevents the crash if the user types "letters" instead of "numbers"
        Console.WriteLine("Error: Please enter the number of the goal, not its name.");
    }
}

    public void SaveGoals()
{
    Console.Write("What is the filename for the goal file? ");
    string fileName = Console.ReadLine();

    try
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // Save the total score first
            outputFile.WriteLine(_score);

            // Iterate through the list and save each goal's string representation
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"\nSuccessfully saved to {fileName}!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error saving goals: {ex.Message}");
    }
}

public void LoadGoals()
{
    Console.Write("What is the filename for the goal file? ");
    string fileName = Console.ReadLine();

    if (!File.Exists(fileName))
    {
        Console.WriteLine("\nError: File not found. Make sure you typed the name correctly.");
        return;
    }

    try
    {
        string[] lines = File.ReadAllLines(fileName);
        _score = int.Parse(lines[0]); // First line is always the score
        _goals.Clear(); // Clear current list before loading from file

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string[] data = parts[1].Split(',');

            if (goalType == "SimpleGoal")
            {
                // Format: Name, Description, Points, IsComplete
                SimpleGoal sg = new SimpleGoal(data[0], data[1], data[2]);
                if (bool.Parse(data[3])) sg.RecordEvent();
                _goals.Add(sg);
            }
            else if (goalType == "EternalGoal")
            {
                // Format: Name, Description, Points
                _goals.Add(new EternalGoal(data[0], data[1], data[2]));
            }
            else if (goalType == "ChecklistGoal")
            {
                // Format: Name, Description, Points, Bonus, Target, AmountCompleted
                int bonus = int.Parse(data[3]);
                int target = int.Parse(data[4]);
                int count = int.Parse(data[5]);
                
                ChecklistGoal cg = new ChecklistGoal(data[0], data[1], data[2], target, bonus);
                // Manually restore the progress count
                for (int j = 0; j < count; j++) cg.RecordEvent();
                _goals.Add(cg);
            }
        }
        Console.WriteLine("\nGoals loaded successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error loading goals: {ex.Message}");
    }
}
}