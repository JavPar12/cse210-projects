using System;

// Represents a goal that is completed once and then finished
public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor passes shared data to the base Goal class
    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        // New goals start as incomplete
        _isComplete = false;
    }

    // Records the goal as finished
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    // Returns true if the goal has been accomplished
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Formats the object data into a single string for saving to a file
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}