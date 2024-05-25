using System;
using System.Collections.Generic;

public class Goal
{
    public string _shortName { get; set; }
    public string _description { get; set; }
    public string _points { get; set; }

    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent() { }
    public virtual bool IsComplete() { return false; }
    public virtual string GetDetailsString() { return string.Empty; }
    public virtual string GetStringRepresentation() { return string.Empty; }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, string points) : base(name, description, points) { }

    public override void RecordEvent() { }
    public override bool IsComplete() { return false; }
    public override string GetStringRepresentation() { return base.GetStringRepresentation(); }
}

public class EternalGoal : Goal
{
    public int _amountCompleted { get; set; }
    public int _target { get; set; }
    public int _bonus { get; set; }

    public EternalGoal(string name, string description, string points) : base(name, description, points) { }

    public override void RecordEvent() { }
    public override bool IsComplete() { return false; }
    public override string GetStringRepresentation() { return base.GetStringRepresentation(); }
}

public class ChecklistGoal : Goal
{
    public int _target { get; set; }
    public int _bonus { get; set; }

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent() { }
    public override bool IsComplete() { return false; }
    public override string GetDetailsString() { return base.GetDetailsString(); }
}

public class GoalManager
{
    private List<Goal> _goals { get; set; }
    private int _score { get; set; }

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        // Start the game logic
    }

    public void DisplayPlayerInfo()
    {
        // Display player info
    }

    public void ListGoalNames()
    {
        // List all goal names
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal._shortName);
        }
    }

    public void ListGoalDetails()
    {
        // List all goal details
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void CreateGoal()
    {
        // Create a new goal
        // Ask the user for the goal details and add it to the list
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the goal points: ");
        string points = Console.ReadLine();

        if (Console.ReadLine().ToLower() == "simple")
        {
            var simpleGoal = new SimpleGoal(name, description, points);
            simpleGoal.RecordEvent();
            _goals.Add(simpleGoal);
        }
        else if (Console.ReadLine().ToLower() == "eternal")
        {
            Console.Write("Enter the target amount: ");
            int target = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the bonus amount: ");
            int bonus = Convert.ToInt32(Console.ReadLine());
            var eternalGoal = new EternalGoal(name, description, points);
            eternalGoal._amountCompleted = 0;
            eternalGoal._target = target;
            eternalGoal._bonus = bonus;
            eternalGoal.RecordEvent();
            _goals.Add(eternalGoal);
        }
        else if (Console.ReadLine().ToLower() == "checklist")
        {
            Console.Write("Enter the target amount: ");
            int target = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the bonus amount: ");
            int bonus = Convert.ToInt32(Console.ReadLine());
            var checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
            checklistGoal.RecordEvent();
            _goals.Add(checklistGoal);
        }
        else
        {
            Console.WriteLine("Invalid goal type. Please try again.");
            CreateGoal();
        }
    }

    public void RecordEvent()
    {
        // Record an event for each goal
        foreach (var goal in _goals)
        {
            goal.RecordEvent();
        }
    }

    public void SaveGoals()
    {
        // Save the goals to a file or database
    }

    public void LoadGoals()
    {
        // Load the goals from a file or database
    }
}