using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store different types of activities (Polymorphism)
        List<Activity> activities = new List<Activity>();

        // Create activity instances
        Running runningActivity = new Running("14 Apr 2026", 30, 4.8);
        Cycling cyclingActivity = new Cycling("14 Apr 2026", 45, 18.5);
        Swimming swimmingActivity = new Swimming("14 Apr 2026", 20, 40);

        // Add activities to the list
        activities.Add(runningActivity);
        activities.Add(cyclingActivity);
        activities.Add(swimmingActivity);

        // Display summaries by iterating through the list
        Console.WriteLine("--- FITNESS CENTER ACTIVITY TRACKER ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}