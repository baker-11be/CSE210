using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> prompts;
    private Random rng = new Random();

    public PromptGenerator()
    {
        prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // Additional prompts
            "What made me smile today?",
            "What challenge did I handle well today?"
        };
    }

    public string GetRandomPrompt()
    {
        if (prompts.Count == 0) return "What's one thing you remember about today?";
        int idx = rng.Next(prompts.Count);
        return prompts[idx];
    }

    // Allow adding custom prompts if desired
    public void AddPrompt(string p)
    {
        if (!string.IsNullOrWhiteSpace(p)) prompts.Add(p);
    }
}
