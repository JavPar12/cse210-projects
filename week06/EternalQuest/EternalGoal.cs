using System;

// EternalGoal inherits from Goal
public class EternalGoal : Goal
{
    // The constructor just passes everything to the parent class.
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    // For an Eternal Goal, recording an event doesn't change a "complete" status.
    // The score logic will be handled by the Manager class later.
    public override void RecordEvent()
    {
        // No status change needed here.
    }

    // An Eternal Goal is never finished, so we always return false.
    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return "";
    }
}