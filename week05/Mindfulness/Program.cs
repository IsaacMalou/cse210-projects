using System;

// EXCEEDING REQUIREMENTS:       
// I added a feature to keep a log of how many times activities were performed. 
// It tracks the count and displays a final message when the user quits.

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;
        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                activityCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                activityCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                activityCount++;
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine($"You completed {activityCount} activities this session.");
        Console.WriteLine("Have a wonderful day!");
    }
}