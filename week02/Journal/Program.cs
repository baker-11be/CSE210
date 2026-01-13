// Journal program
// Features: write entries from random prompts, display, save/load to file.
// Enhancement: supports JSON (.json) save/load and sanitizes newlines on save to keep one entry per line for text files.
using System;
class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        bool keepGoing = true;
        while (keepGoing)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, prompts);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    keepGoing = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void WriteEntry(Journal journal, PromptGenerator prompts)
    {
        string prompt = prompts.GetRandomPrompt();
        Console.WriteLine();
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();
        var e = new Entry(date, prompt, response);
        journal.AddEntry(e);

        Console.WriteLine("Entry added.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Filename to save to (include extension .txt or .json): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided. Save cancelled.");
            return;
        }

        try
        {
            journal.SaveToFile(filename);
            Console.WriteLine($"Saved journal to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save: " + ex.Message);
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Filename to load from (include extension .txt or .json): ");
        string filename = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("No filename provided. Load cancelled.");
            return;
        }

        try
        {
            journal.LoadFromFile(filename);
            Console.WriteLine($"Loaded journal from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load: " + ex.Message);
        }
    }
}