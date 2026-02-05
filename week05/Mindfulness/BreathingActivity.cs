using System;

public class BreathingActivity : Activity
{
    private static int _activityCount = 0;
    
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _activityCount++;
    }
    
    protected override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("\n\nBreathe in... ");
            ShowCountdown(4);
            
            if (DateTime.Now >= endTime) break;
            
            Console.Write("\nBreathe out... ");
            ShowCountdown(6);
        }
    }
    
    public static int GetActivityCount()
    {
        return _activityCount;
    }
}