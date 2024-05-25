

public class ChecklistGoal : Goal

    public int _target { get; set; }
    public int _bonus { get; set; }

    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    
        _target = target;
        _bonus = bonus;
    

    public override void RecordEvent() { }
    public override bool IsComplete() { return false; }
    public override string GetDetailsString() { return base.GetDetailsString(); }
