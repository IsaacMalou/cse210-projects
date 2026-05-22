using System;

// Exceeding Requirements Note:
// I implemented the stretch challenge to ensure that the program 
// only selects words that are not already hidden when randomly choosing words to hide.

class Program
{
    static void Main(string[] args)
    {
        // Set up the reference and scripture text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // Main program loop
        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");

            userInput = Console.ReadLine();

            // Hide 3 words at a time if they press enter
            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        // Display the final fully-hidden scripture before the program ends completely
        if (scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("You have successfully memorized the scripture!");
        }
    }
}