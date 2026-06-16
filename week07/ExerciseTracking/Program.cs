using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold activities
        List<Activity> activities = new List<Activity>();

        // Instantiate one of each derived class
        Running running = new Running("03 Nov 2022", 30, 4.8);   // 4.8 kilometers
        Cycling cycling = new Cycling("04 Nov 2022", 45, 20.0);  // 20 kph speed
        Swimming swimming = new Swimming("05 Nov 2022", 25, 40); // 40 laps

        // Add the activities to the list
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        Console.WriteLine("Exercise Tracking Summaries:");
        Console.WriteLine("----------------------------");

        // Use polymorphism to call GetSummary() on each activity in the list
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}