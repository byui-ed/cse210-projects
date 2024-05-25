using System;

public class Goal

    public string _shortName { get; set; }
    public string _description { get; set; }
    public string _points { get; set; }

    public Goal(string name, string description, string points)
    
        _shortName = name;
        _description = description;
        _points = points;
    

    public virtual void RecordEvent() { }
    public virtual bool IsComplete() { return false; }
    public virtual string GetDetailsString() { return string.Empty; }
    public virtual string GetStringRepresentation() { return string.Empty; }
