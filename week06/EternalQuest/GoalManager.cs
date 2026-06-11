using System;
using System.Collections.Generic;
using System.IO;
using System.Threading; // Required for animations

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.Clear(); // Keeps the terminal clean
            DisplayPlayerInfo();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Menu Options:");
            Console.ResetColor();
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nSelect a choice from the menu: ");
            Console.ResetColor();
            choice = Console.ReadLine();

            Console.WriteLine(); // Spacing

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();

            if (choice != "6")
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Keep up the great work! Goodbye.");
        Console.ResetColor();
    }

    private string GetPlayerTitle()
    {
        if (_score >= 1000) return "Master Achiever";
        if (_score >= 500) return "Elite Performer";
        if (_score >= 100) return "Dedicated Apprentice";
        return "Novice Beginner";
    }

    public void DisplayPlayerInfo()
    {
        int playerLevel = (_score / 300) + 1;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("========================================");
        Console.WriteLine($"  Title: {GetPlayerTitle()}");
        Console.WriteLine($"  Level: {playerLevel}");
        Console.WriteLine($"  Score: {_score} points");
        Console.WriteLine("========================================\n");
        Console.ResetColor();
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  (No goals available.)");
            Console.ResetColor();
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  [ No goals created yet. Choose option 1 to add one. ]");
            Console.ResetColor();
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n× Invalid selection! Please enter 1, 2, or 3.");
            Console.ResetColor();
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("× Invalid input. Please enter a whole number for points: ");
            Console.ResetColor();
        }

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target)) Console.Write("Please enter a number: ");

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus;
            while (!int.TryParse(Console.ReadLine(), out bonus)) Console.Write("Please enter a number: ");

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Success: '{name}' has been added!");
        Console.ResetColor();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("You have no goals to accomplish yet.");
            Console.ResetColor();
            return;
        }

        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? ");

        // Bulletproof input parsing
        if (!int.TryParse(Console.ReadLine(), out int input) || input < 1 || input > _goals.Count)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("× Invalid goal selection.");
            Console.ResetColor();
            return;
        }

        int index = input - 1;
        Goal goal = _goals[index];
        goal.RecordEvent();

        int pointsEarned = goal.GetPoints();
        _score += pointsEarned;

        ShowSpinner("Recording progress... ", 1);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nCongratulations! You have earned {pointsEarned} points!");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"You now have {_score} points.");
        Console.ResetColor();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        ShowSpinner("Saving data... ", 1);

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Goals saved successfully.");
        Console.ResetColor();
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            ShowSpinner("Loading profile... ", 1);

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                string name = details[0];
                string description = details[1];
                int points = int.Parse(details[2]);

                if (type == "SimpleGoal")
                {
                    SimpleGoal sg = new SimpleGoal(name, description, points);
                    bool isComplete = bool.Parse(details[3]);
                    if (isComplete) sg.RecordEvent();
                    _goals.Add(sg);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, description, points));
                }
                else if (type == "ChecklistGoal")
                {
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int amountCompleted = int.Parse(details[5]);

                    ChecklistGoal cg = new ChecklistGoal(name, description, points, target, bonus);
                    for (int j = 0; j < amountCompleted; j++)
                    {
                        cg.RecordEvent();
                    }
                    _goals.Add(cg);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✓ Goals loaded successfully.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("× File not found.");
            Console.ResetColor();
        }
    }

    // Creates a cool little terminal animation
    private void ShowSpinner(string message, int durationSeconds)
    {
        Console.Write(message);
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
        int i = 0;

        // Hide cursor during animation
        Console.CursorVisible = false;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(150);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Length;
        }

        Console.CursorVisible = true;
    }
}