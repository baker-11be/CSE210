using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    // Method to hide random words
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;

        // Get list of words that are not yet hidden
        List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        // If there are no visible words left, return
        if (visibleWords.Count == 0)
        {
            return;
        }

        // Hide random words from the visible words
        while (wordsHidden < numberToHide && visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
            wordsHidden++;
        }
    }

    // Method to display the scripture
    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        
        Console.WriteLine();

        // Display progress
        int totalWords = _words.Count;
        int hiddenWords = _words.Count(w => w.IsHidden());
        int percentage = totalWords > 0 ? (hiddenWords * 100) / totalWords : 0;
        Console.WriteLine($"\nProgress: {percentage}% hidden ({hiddenWords}/{totalWords} words)");
    }

    // Method to check if all words are hidden
    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }

    // Method to reset all words to visible (for starting a new session)
    public void Reset()
    {
        foreach (Word word in _words)
        {
            word.Show();
        }
    }
}
