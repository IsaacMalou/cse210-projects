using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;

    // Initialize the list immediately so it's ready to use
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        // Iterate through each job and call its own Display method
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}