using System;

public abstract class Activity
{
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Protected getter for minutes to allow child classes to access it
    protected int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods that must be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Method to get a summary of the activity
    public string GetSummary()
    {
        // Use the type of the derived class to display the activity type in the summary
        return $"{_date} {this.GetType().Name} ({_minutes} min): Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}