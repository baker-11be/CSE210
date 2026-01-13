using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

public class Journal
{
    private List<Entry> entries = new List<Entry>();

    public void AddEntry(Entry e)
    {
        if (e != null) entries.Add(e);
    }

    public void DisplayEntries()
    {
        Console.WriteLine("--- Journal Entries ---");
        if (entries.Count == 0)
        {
            Console.WriteLine("(no entries)");
            return;
        }

        foreach (var e in entries)
        {
            Console.WriteLine(e);
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename)) return;

        // If user wants json, save as JSON for interoperability
        if (filename.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(entries, options);
            File.WriteAllText(filename, json);
            return;
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var e in entries)
            {
                writer.WriteLine(e.ToFileString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (string.IsNullOrWhiteSpace(filename)) return;

        // If json -> parse
        if (filename.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
        {
            string json = File.ReadAllText(filename);
            try
            {
                var loaded = JsonSerializer.Deserialize<List<Entry>>(json);
                if (loaded != null)
                {
                    entries = loaded;
                }
            }
            catch
            {
                Console.WriteLine("Failed to parse JSON file.");
            }

            return;
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return;
        }

        var lines = File.ReadAllLines(filename);
        var newEntries = new List<Entry>();
        foreach (var line in lines)
        {
            var e = Entry.FromFileString(line);
            if (e != null) newEntries.Add(e);
        }

        // Replace current entries with loaded ones
        entries = newEntries;
    }
}
