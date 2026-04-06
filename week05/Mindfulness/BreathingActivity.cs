using System;

public class BreathingActivity : Activity
{
    // The builder sends the name and description to the Parent (Activity)
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        // 1. We use the methods we inherited from the father
        DisplayStartingMessage();

        // 2. Breathing logic (Loop until time runs out)
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(4);
            
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }

        // 3. final inherited message
        DisplayEndingMessage();
    }
}