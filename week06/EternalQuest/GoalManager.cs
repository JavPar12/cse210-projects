using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // This is the "Main" loop of the game. It displays the menu.
    public void Start()
    {
        // For now, it stays empty. We will build the loop next week.
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou have {_score} points.\n");
    }

    public void ListGoalNames()
    {
        // Logic to list only the names of goals
    }

    public void ListGoalDetails()
    {
        // Logic to list the full details (the [ ] name (description) -- 0/3)
    }

    public void CreateGoal()
    {
        // Logic to ask the user what kind of goal they want to make
    }

    public void RecordEvent()
    {
        // Logic to ask which goal the user completed
    }

    public void SaveGoals()
    {
        // Logic to save the list to a .txt file
    }

    public void LoadGoals()
    {
        // Logic to read from a .txt file
    }
}