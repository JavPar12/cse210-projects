using System;

// Abstract base class that defines the core structure of all goals
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    // Constructor to initialize the shared attributes
    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract method to record progress (must be implemented by child classes)
    public abstract void RecordEvent();

    // Abstract method to check if the goal is finished
    public abstract bool IsComplete();
    
    // Virtual method to display goal status and details
    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    // Abstract method to format data for file storage
    public abstract string GetStringRepresentation();
}