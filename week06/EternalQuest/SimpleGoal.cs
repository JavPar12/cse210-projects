using System;

// SimpleGoal inherits from Goal
public class SimpleGoal : Goal
{
    private bool _isComplete;

    // The constructor takes name, description, and points, 
    // and passes them to the 'base' class (Goal).
    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        // When we first create a goal, it is not complete.
        _isComplete = false;
    }

    // This overrides the abstract method from the parent.
    // Marking a simple goal as recorded means it is now complete.
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    // Returns the status of the goal.
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // We will fill this in later for saving/loading.
    public override string GetStringRepresentation()
    {
        return ""; 
    }
}