

public class EternalGoal : Goal

    public int _amountCompleted { get; set; }
    public int _target { get; set; }
    public int _bonus { get; set; }

    public EternalGoal(string name, string description, string points) : base(name, description, points) { }

    public override void RecordEvent() { }
    public override bool IsComplete() { return false; }
    public override string GetStringRepresentation() { return base.GetStringRepresentation(); }
