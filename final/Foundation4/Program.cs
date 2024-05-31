using System;

public abstract class Activity
{
    protected DateTime Date;
    protected int Minutes;

    protected Activity(DateTime date, int minutes)
    {
        Date = date;
        Minutes = minutes;
    }

    protected abstract decimal GetDistance();
    protected abstract decimal GetSpeed();
    protected abstract decimal GetPace();

    public override string ToString()
    {
        return $"{Date} - Activity ({Minutes} min)";
    }

    protected virtual string GetSummary()
    {
        return $"{Date} - Activity ({Minutes} min)\nDistance: {(GetDistance():F2)} km\nSpeed: {(GetSpeed():F2)} kph\nPace: {(GetPace():F2)} min per km";
    }
}

public class Running : Activity
{
    protected decimal Distance;

    protected Running(DateTime date, int minutes, decimal distance)
        : base(date, minutes)
    {
        Distance = distance;
    }

    protected override decimal GetDistance()
    {
        return Distance;
    }

    protected override decimal GetSpeed()
    {
        return (Distance / Minutes) * 60;
    }

    protected override decimal GetPace()
    {
        return Minutes / Distance;
    }
}

public class Cycling : Activity
{
    protected decimal Speed;

    protected Cycling(DateTime date, int minutes, decimal speed)
        : base(date, minutes)
    {
        Speed = speed;
    }

    protected override decimal GetDistance()
    {
        return (Speed / Minutes) * 60;
    }

    protected override decimal GetSpeed()
    {
        return Speed;
    }

    protected override decimal GetPace()
    {
        return (60 / Speed);
    }
}

public class Swimming : Activity
{
    protected int Laps;

    protected Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        Laps = laps;
    }

    protected override decimal GetDistance()
    {
        return Laps * 50 / 1000m;
    }

    protected override decimal GetSpeed()
    {
        // speed calculation here
        // same for pace calculation here
        // implement the rest of the logic for swimming activity here
        throw new NotImplementedException();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity runningActivity1 = new Running(DateTime.Now, 30, 4.8m);
        Console.WriteLine(runningActivity1.ToString());
        Console.WriteLine(runningActivity1.GetSummary());

        Activity cyclingActivity1 = new Cycling(DateTime.Now, 45, 25.5m);
        Console.WriteLine(cyclingActivity1.ToString());
        Console.WriteLine(cyclingActivity1.GetSummary());

        Activity swimmingActivity1 = new Swimming(DateTime.Now, 20, 5);
        Console.WriteLine(swimmingActivity1.ToString());
        Console.WriteLine(swimmingActivity1.GetSummary());
     }
}