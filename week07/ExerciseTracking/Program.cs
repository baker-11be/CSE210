using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities of each type
        Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Cycling cycling = new Cycling(new DateTime(2022, 11, 4), 45, 12.5);
        Swimming swimming = new Swimming(new DateTime(2022, 11, 5), 60, 40);

        // Put them in the same list (polymorphism in action!)
        List<Activity> activities = new List<Activity>();
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Iterate through the list and display summaries
        Console.WriteLine("Exercise Tracking Summary");
        Console.WriteLine("=========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}