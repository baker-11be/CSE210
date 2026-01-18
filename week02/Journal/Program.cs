// Journal program
// Features: write entries from random prompts, display, save/load to file.
// Enhancement (exceeds core): supports JSON (.json) save/load and sanitizes newlines when writing text so each entry stays on one line.
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
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
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
                    LoadJournal(journal);
                    break;
                case "4":
                    SaveJournal(journal);
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
        Console.WriteLine(prompt);
        Console.Write("> ");
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