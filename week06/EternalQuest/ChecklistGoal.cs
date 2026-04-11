using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // The constructor takes more parameters now to set the target and bonus.
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Every time we record an event, we increment the count.
    public override void RecordEvent()
    {
        _amountCompleted++;
    }

    // It is only complete if the amount done matches or exceeds the target.
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    // We override this to show the progress (e.g., "Completed 3/10")
    public override string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return "";
    }
}