using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private int _count;
    private static int _activityCount = 0;
    
    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _activityCount++;
    }
    
    protected override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        
        Console.WriteLine();
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        _count = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                _count++;
            }
        }
        
        Console.WriteLine($"\nYou listed {_count} items!");
    }
    
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
    
    public static int GetActivityCount()
    {
        return _activityCount;
    }
}