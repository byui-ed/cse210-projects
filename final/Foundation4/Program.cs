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

    public override string ToString()
    {
        return string.Format("{0} - Activity ({1} min)", Date, Minutes);
    }

    public abstract string GetSummary();
}

public class RunningActivity : Activity
{
    protected decimal Distance;

    public RunningActivity(DateTime date, int minutes, decimal distance)
        : base(date, minutes)
    {
        Distance = distance;
    }

    public override string GetSummary()
    {
        return $"{base.ToString()}\nDistance: {Distance.ToString("F2")} km\nSpeed: {(Distance / Minutes) * 60:0.##} kph\nPace: {(Minutes / Distance):0.##} min per km";
    }
}

public class CyclingActivity : Activity
{
    protected decimal Speed;

    public CyclingActivity(DateTime date, int minutes, decimal speed)
        : base(date, minutes)
    {
        Speed = speed;
    }

    public override string GetSummary()
    {
        return $"{base.ToString()}\nDistance: {(Speed / Minutes) * 60:0.##} km\nSpeed: {Speed:0.##} kph\nPace: {(60 / Speed):0.##} min per km";
    }
}

public class SwimmingActivity : Activity
{
    protected int Laps;

    public SwimmingActivity(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        Laps = laps;
    }

    public override string GetSummary()
    {
        return $"{base.ToString()}\nDistance: {(Laps * 50 / 1000m):F2} km\nSpeed: ??? (Not Implemented)\nPace: ??? (Not Implemented)";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Activity runningActivity1 = new RunningActivity(DateTime.Now, 30, 4.8m);
        Console.WriteLine(runningActivity1.ToString());
        Console.WriteLine(runningActivity1.GetSummary());

        Activity cyclingActivity1 = new CyclingActivity(DateTime.Now, 45, 25.5m);
        Console.WriteLine(cyclingActivity1.ToString());
        Console.WriteLine(cyclingActivity1.GetSummary());

        Activity swimmingActivity1 = new SwimmingActivity(DateTime.Now, 20, 5);
        Console.WriteLine(swimmingActivity1.ToString());
        Console.WriteLine(swimmingActivity1.GetSummary());
    }
}