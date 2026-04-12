using System;

// Represents a goal that is never fully completed but provides points each time
public class EternalGoal : Goal
{
    // Constructor passes shared data to the base Goal class
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
        // No extra variables needed as this goal never changes state
    }

    // Records the event. For eternal goals, there is no 'complete' status to update.
    public override void RecordEvent()
    {
        // Points will be added by the Manager, but the goal remains active
    }

    // An eternal goal is never finished, so it always returns false
    public override bool IsComplete()
    {
        return false;
    }

    // Formats the data for file storage
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}