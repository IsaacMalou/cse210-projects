using System;

// CREATIVITY AND EXCEEDING REQUIREMENTS DESCRIPTION:
// To exceed the core requirements, I added a "Mood Tracker" feature to the journal program. 
// When writing a new entry, the user is prompted to input their current mood (e.g., Happy, Stressed, Tired). 
// This extra detail is successfully stored as an independent property in the Entry class, displays 
// uniquely when rendering the journal, and saves/loads perfectly using a custom '|' data parser.

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {randomPrompt}");
                Console.Write("> ");
                string userResponse = Console.ReadLine();

                Console.Write("What is your current mood? ");
                string userMood = Console.ReadLine();

                string dateText = DateTime.Now.ToShortDateString();

                Entry newEntry = new Entry();
                newEntry._date = dateText;
                newEntry._promptText = randomPrompt;
                newEntry._entryText = userResponse;
                newEntry._mood = userMood;

                theJournal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                theJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                theJournal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a number from 1 to 5.");
            }
        }
    }
}