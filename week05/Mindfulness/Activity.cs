using System;
using System.Collections.Generic;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static int _totalActivities = 0;
    protected static List<string> _completionMessages = new List<string>();
    
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        _duration = GetDuration();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
        _totalActivities++;
        _completionMessages.Add($"Completed {_name} for {_duration} seconds");
    }
    
    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }
    
    protected int GetDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        return int.Parse(Console.ReadLine());
    }
    
    protected void PrepareToBegin()
    {
        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }
    
    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        ShowSpinner(3);
    }
    
    protected void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        int animationIndex = 0;
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        
        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[animationIndex]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            animationIndex = (animationIndex + 1) % animationStrings.Count;
        }
        Console.Write(" ");
    }
    
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.Write(" ");
    }
    
    protected abstract void PerformActivity();
    
    public static int GetTotalActivityCount()
    {
        return _totalActivities;
    }
    
    public static List<string> GetCompletionMessages()
    {
        return _completionMessages;
    }
}