using System;

// We mark the class as 'abstract' because a generic "Goal" doesn't exist.
// It will always be a Simple, Eternal, or Checklist goal.
public abstract class Goal
{
    // We use 'protected' so that child classes can access these variables directly.
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // These methods are abstract because each child handles them differently.
    // They don't have a body { } here; they end with a semicolon.
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    
    // This method is 'virtual' because it provides a default implementation
    // that most goals can use, but some (like Checklist) can override later.
    public virtual string GetDetailsString()
    {
        return $"[ ] {_shortName} ({_description})";
    }

    // This will be used to format the goal data for saving to a file.
    public abstract string GetStringRepresentation();
}