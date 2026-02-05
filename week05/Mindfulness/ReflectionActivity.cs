using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private static List<string> _usedQuestions = new List<string>();
    private static int _activityCount = 0;
    
    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        _activityCount++;
    }
    
    protected override void PerformActivity()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
        
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            if (_usedQuestions.Count == _questions.Count)
            {
                _usedQuestions.Clear();
            }
            
            string question = GetRandomUnusedQuestion();
            Console.Write($"\n> {question} ");
            ShowSpinner(10);
            
            if (DateTime.Now >= endTime) break;
        }
    }
    
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
    
    private string GetRandomUnusedQuestion()
    {
        Random random = new Random();
        List<string> availableQuestions = new List<string>();
        
        foreach (string question in _questions)
        {
            if (!_usedQuestions.Contains(question))
            {
                availableQuestions.Add(question);
            }
        }
        
        if (availableQuestions.Count == 0)
        {
            _usedQuestions.Clear();
            return GetRandomUnusedQuestion();
        }
        
        string selectedQuestion = availableQuestions[random.Next(availableQuestions.Count)];
        _usedQuestions.Add(selectedQuestion);
        return selectedQuestion;
    }
    
    public static int GetActivityCount()
    {
        return _activityCount;
    }
}