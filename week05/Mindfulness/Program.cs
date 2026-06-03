using System;

// EXCEEDING REQUIREMENTS:                                                              // <--- The Comment
// I added a feature to keep a log of how many times activities were performed. 
// It tracks the count and displays a final message when the user quits.

class Program
{
    static void Main(string[] args)
    {
        int activityCount = 0;                                                          // <--- Step 1: Create the variable here

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
                activityCount++;                                                        // <--- Step 2: Add 1 for breathing
            }
            else if (choice == "2")
            {
                // ReflectingActivity reflecting = new ReflectingActivity();
                // reflecting.Run();

                Console.WriteLine("Reflecting Activity coming soon! Press Enter.");
                Console.ReadLine();
                // activityCount++;                                                     // (Uncomment this when Reflecting is built)
            }
            else if (choice == "3")
            {
                // ListingActivity listing = new ListingActivity();
                // listing.Run();

                Console.WriteLine("Listing Activity coming soon! Press Enter.");
                Console.ReadLine();
                // activityCount++;                                                     // (Uncomment this when Listing is built)
            }
        }

        // Step 3: Print the final total after the while loop finishes                 // <--- Step 3: The final message
        Console.WriteLine();
        Console.WriteLine($"Thank you for using the Mindfulness Program!");
        Console.WriteLine($"You completed {activityCount} activities this session.");
        Console.WriteLine("Have a wonderful day!");
    }
}