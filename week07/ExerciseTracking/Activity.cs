using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods to be overridden by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method that can be used by all derived classes
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min)- " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F2} min per mile";
    }
}