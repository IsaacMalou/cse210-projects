using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Create Video 1 and add comments
        Video video1 = new Video("Learning C# in 10 Minutes", "Code Academy", 600);
        video1.AddComment(new Comment("Deng", "This was incredibly helpful, thank you!"));
        video1.AddComment(new Comment("Majak", "I finally understand how classes work."));
        video1.AddComment(new Comment("Kiden", "Can you make a video on inheritance next?"));

        // 2. Create Video 2 and add comments
        Video video2 = new Video("Top 10 Programming Mistakes", "Dev Guru", 850);
        video2.AddComment(new Comment("Lual", "I make mistake #3 all the time..."));
        video2.AddComment(new Comment("Achan", "Great video as always!"));
        video2.AddComment(new Comment("Nyok", "The audio is a little bit low on this one."));

        // 3. Create Video 3 and add comments
        Video video3 = new Video("A Day in the Life of a Software Engineer", "Tech Life", 1200);
        video3.AddComment(new Comment("Garang", "Your office setup looks amazing!"));
        video3.AddComment(new Comment("Akol", "Thanks for sharing your daily routine."));
        video3.AddComment(new Comment("Poni", "Do you work remotely full-time?"));

        // Store all videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list of videos and display their information
        foreach (Video video in videos)
        {
            video.DisplayInfo();
        }
    }
}