using System;

public class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    public virtual string GetStandardDetails()
    {
        return $"Title: {Title}, Description: {Description}, Date: {Date}, Time: {Time}, Address: {Address.ToString()}";
    }

    public virtual string GetFullDetails()
    {
        throw new NotImplementedException();
    }

public virtual string GetShortDescription()
{
    return $"Title: {Title}";
}
}


public class Lecture : Event
{
    public string SpeakerName { get; set; }
    public int Capacity { get; set; }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $", Speaker: {SpeakerName}, Capacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Title: {Title}, Speaker: {SpeakerName}";
    }
}

public class Reception : Event
{
    public string RSVPEmail { get; set; }

    public override string GetFullDetails()
    {
        return base.GetStandardDetails() + $", RSVP Email: {RSVPEmail}";
    }
}

public class OutdoorGathering : Event
{
    public override string GetFullDetails()
    {
        return base.GetStandardDetails(); // You can also implement your own logic here
    }

    public override string GetShortDescription()
    {
        return base.GetStandardDetails(); // You can also implement your own logic here
    }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{StreetAddress}, {City}, {StateProvince}, {Country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Event lectureEvent = new Lecture()
        {
            Title = "Lecture Event",
            Description = "This is a lecture event",
            Date = DateTime.Now,
            Time = TimeSpan.FromHours(10),
            Address = new Address()
            {
                StreetAddress = "123 Main St",
                City = "Anytown",
                StateProvince = "CA",
                Country = "USA"
            },
            SpeakerName = "John Doe",
            Capacity = 100
        };

        Event receptionEvent = new Reception()
        {
            Title = "Reception Event",
            Description = "This is a reception event",
            Date = DateTime.Now,
            Time = TimeSpan.FromHours(10),
            Address = new Address()
            {
                StreetAddress = "123 Main St",
                City = "Anytown",
                StateProvince = "CA",
                Country = "USA"
            },
            RSVPEmail = "john.doe@example.com"
        };

        Event outdoorGatheringEvent = new OutdoorGathering()
        {
            Title = "Outdoor Gathering Event",
            Description = "This is an outdoor gathering event",
            Date = DateTime.Now,
            Time = TimeSpan.FromHours(10),
            Address = new Address()
            {
                StreetAddress = "123 Main St",
                City = "Anytown",
                StateProvince = "CA",
                Country = "USA"
            }
            // weather forecast code here
        };

        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());

        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());

        Console.WriteLine(outdoorGatheringEvent.GetStandardDetails());
        // outdoorGatheringEvent.GetFullDetails(); // This will throw an exception because GetFullDetails is not implemented
        // outdoorGatheringEvent.GetShortDescription(); // This will throw an exception because GetShortDescription is not implemented
    }
}
