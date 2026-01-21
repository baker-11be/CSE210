using System;

// Exceeding Requirements:
// 1. Added a library of scriptures - program randomly selects from multiple scriptures
// 2. User can memorize multiple scriptures in one session
// 3. Added color coding for better user experience (hidden words in gray)
// 4. Tracks progress percentage of hidden words

class Program
{
    static void Main(string[] args)
    {
        // Create a library of scriptures
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), 
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), 
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding; In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Nephi", 3, 7), 
                "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.")
        };

        bool continueProgram = true;

        while (continueProgram)
        {
            // Randomly select a scripture from the library
            Random random = new Random();
            Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            // Reset the scripture for a new session
            scripture.Reset();

            bool continueHiding = true;

            while (continueHiding)
            {
                Console.Clear();
                scripture.Display();
                
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden! Great job!");
                    break;
                }

                Console.WriteLine("\n\nPress Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    continueHiding = false;
                    continueProgram = false;
                }
                else
                {
                    scripture.HideRandomWords(3); // Hide 3 words at a time
                }
            }

            if (continueProgram)
            {
                Console.WriteLine("\nWould you like to memorize another scripture? (yes/no):");
                string response = Console.ReadLine();
                if (response.ToLower() != "yes")
                {
                    continueProgram = false;
                }
            }
        }

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}