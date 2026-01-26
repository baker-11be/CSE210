using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to store videos
        List<Video> videos = new List<Video>();

        // Create and configure first video
        Video video1 = new Video("C# Tutorial for Beginners", "Programming with Mosh", 600);
        video1.AddComment(new Comment("Alice Baker", "Great tutorial! Very helpful for beginners."));
        video1.AddComment(new Comment("Bob Smith", "I wish you covered more advanced topics too."));
        video1.AddComment(new Comment("Charlie Brown", "Clear explanations, but the audio could be better."));
        video1.AddComment(new Comment("Diana Prince", "Perfect pace for someone new to programming!"));
        
        // Create and configure second video
        Video video2 = new Video("ASP.NET Core Web API Tutorial", "Microsoft Developer", 1200);
        video2.AddComment(new Comment("Emma Watson", "Excellent walkthrough of REST principles."));
        video2.AddComment(new Comment("Frank Kepo", "Can you make a video on authentication next?"));
        video2.AddComment(new Comment("Grace Baker", "Very comprehensive. Learned a lot!"));
        
        // Create and configure third video
        Video video3 = new Video("Entity Framework Core Basics", "Code Academy", 900);
        video3.AddComment(new Comment("Henry Ford", "The database examples were very practical."));
        video3.AddComment(new Comment("Yvnne", "Some parts were too fast for me."));
        video3.AddComment(new Comment("Jack Ryan", "Great content! Subscribed to your channel."));
        video3.AddComment(new Comment("Karen White", "Would love to see more real-world examples."));
        
        // Create and configure fourth video
        Video video4 = new Video("Design Patterns in C#", "Software University", 1800);
        video4.AddComment(new Comment("Leo Peterson", "Finally understand the Singleton pattern!"));
        video4.AddComment(new Comment("Mary Iratuzi", "The factory pattern explanation was brilliant."));
        video4.AddComment(new Comment("Neil Isaac", "Complex topic made simple. Thank you!"));

        // Add all videos to the list
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Iterate through the list and display video information
        foreach (Video video in videos)
        {
            Console.WriteLine("=========================================");
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}