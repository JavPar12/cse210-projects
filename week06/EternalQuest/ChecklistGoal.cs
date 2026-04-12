using System;

// Represents a goal that requires multiple completions to finish and earn a bonus
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor initializes progress to zero and sets the target and bonus
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Increments the completion count
    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    // Returns true only if the amount completed reaches or exceeds the target
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // Overrides the detail string to show current progress (e.g., 2/5)
    public override string GetDetailsString()
    {
        return $"{_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Formats data for file storage, including the extra progress variables
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}