using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry() { }

    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Convert to a single-line representation for file storage
    // Using a separator unlikely to appear in normal text: ~|~
    private const string SEP = "~|~";

    public string ToFileString()
    {
        // Replace any newline characters in response so each entry is one line
        string safeResponse = Response?.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ") ?? "";
        string safePrompt = Prompt?.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ") ?? "";
        return $"{Date}{SEP}{safePrompt}{SEP}{safeResponse}";
    }

    public static Entry FromFileString(string line)
    {
        const string sep = "~|~";
        string[] parts = line.Split(new string[] { sep }, StringSplitOptions.None);
        if (parts.Length < 3)
        {
            // not a valid line
            return null;
        }

        return new Entry(parts[0], parts[1], parts[2]);
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}";
    }
}
