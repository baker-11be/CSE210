using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness Program!");
        Console.WriteLine("This program offers various mindfulness activities to help you relax and reflect.");
        
        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Start Breathing Activity");
            Console.WriteLine("  2. Start Reflection Activity");
            Console.WriteLine("  3. Start Listing Activity");
            Console.WriteLine("  4. Show Activity Statistics");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            
            Activity activity = null;
            
            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    DisplayStatistics();
                    continue;
                case "5":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Have a peaceful day!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
            
            activity.Run();
        }
    }
    
    static void DisplayStatistics()
    {
        Console.WriteLine("\n=== Activity Statistics ===");
        Console.WriteLine($"Total Activities Completed: {Activity.GetTotalActivityCount()}");
        Console.WriteLine($"Breathing Activities: {BreathingActivity.GetActivityCount()}");
        Console.WriteLine($"Reflection Activities: {ReflectionActivity.GetActivityCount()}");
        Console.WriteLine($"Listing Activities: {ListingActivity.GetActivityCount()}");
        
        if (Activity.GetTotalActivityCount() > 0)
        {
            Console.WriteLine("\nActivity Completion Messages:");
            List<string> messages = Activity.GetCompletionMessages();
            foreach (string message in messages)
            {
                Console.WriteLine($"- {message}");
            }
        }
        else
        {
            Console.WriteLine("No activities completed yet.");
        }
    }
}