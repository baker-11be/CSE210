using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        
        // Test 1: Create first job and display company
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;
        
        // Display just the company (as requested)
        Console.WriteLine(job1._company);
        
        // Test 2: Create second job and display company
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;
        
        // Display just the company (as requested)
        Console.WriteLine(job2._company);
        
        Console.WriteLine("\n--- Using Display Method ---");
        // Now use the Display method instead
        job1.Display();
        job2.Display();
        
        // Test 3: Create and test Resume class
        Console.WriteLine("\n--- Testing Resume Class ---");
        
        // Create resume instance
        Resume myResume = new Resume();
        myResume._personName = "Allison Rose";
        
        // Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        // Test accessing first job title
        Console.WriteLine($"First job title: {myResume._jobs[0]._jobTitle}");
        
        // Display the full resume
        Console.WriteLine("\n--- Final Resume Display ---");
        myResume.Display();
    }
}