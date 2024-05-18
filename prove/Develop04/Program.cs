using System;

class Program
{
    static void Main(string[] args)
}

public abstract class Activity
{
    public string _name;
    public string _description;
    public int _duration;

    public Activity() { }

    public virtual void Run()
    {
        Console.WriteLine("Starting activity...");
        DisplayStartingMessage();
        for (int i = 0; i < _duration * 60; i++) // Loop for the duration in seconds
        {
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }
        DisplayEndingMessage();
        ShowCountDown(_duration * 60);
    }

    public virtual void DisplayStartingMessage()
    {
        Console.WriteLine("Starting " + _name);
    }

    public virtual void DisplayEndingMessage()
    {
        Console.WriteLine("Ending " + _name);
    }

    public virtual void ShowCountDown(int duration)
    {
        for (int i = duration; i > 0; i--)
        {
            Console.WriteLine("Time remaining: " + i);
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine("Time's up!");
    }
}

public class ListingActivity : Activity
{
    public int _count;
    public List<string> _prompts;

    public ListingActivity() : base()
    {
        _name = "Listing Activity";
        _description = "This activity involves listing items based on prompts.";
        _duration = 5; // Default duration in minutes
        _count = 0;
        _prompts = new List<string>();
    }

    public override void Run()
    {
        Console.WriteLine("Starting Listing Activity...");
        DisplayStartingMessage();

        // Run the activity
        for (int i = 0; i < _duration * 60; i++) // Loop for the duration in seconds
        {
            GetListFromUser();
            GetRandomPrompt();
            Console.WriteLine("Count: " + _count);
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }

        DisplayEndingMessage();
        ShowCountDown(_duration * 60);
    }

    public void GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(0, _prompts.Count);
        Console.WriteLine("Prompt: " + _prompts[promptIndex]);
    }

    public List<string> GetListFromUser()
    {
        List<string> userInput = new List<string>();

        Console.WriteLine("Enter items to list (type 'stop' to finish):");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "stop")
                break;
            userInput.Add(input);
        }

        _count = userInput.Count;
        return userInput;
    }
}

public class BreathingActivity : Activity
{
    public int _breaths;

    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This activity involves breathing exercises.";
        _duration = 5; // Default duration in minutes
    }

    public override void Run()
    {
        Console.WriteLine("Starting Breathing Activity...");
        DisplayStartingMessage();

        // Run the activity
        for (int i = 0; i < _duration * 60; i++) // Loop for the duration in seconds
        {
            Breathe();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }

        DisplayEndingMessage();
        ShowCountDown(_duration * 60);
    }

    public void Breathe()
    {
        Console.WriteLine("Breathe in...");
        System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
        Console.WriteLine("Hold your breath...");
        System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
        Console.WriteLine("Breathe out...");
        System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
    }
}

public class ReflectingActivity : Activity
{
    public List<string> _prompts;
    public List<string> _questions;

    public ReflectingActivity() : base()
    {
        _name = "Reflecting Activity";
        _description = "This activity involves reflecting on your thoughts and feelings.";
        _duration = 5; // Default duration in minutes
        _prompts = new List<string>();
        _questions = new List<string>();
    }

    public override void Run()
    {
        Console.WriteLine("Starting Reflecting Activity...");
        DisplayStartingMessage();

        // Run the activity
        for (int i = 0; i < _duration * 60; i++) // Loop for the duration in seconds
        {
            GetRandomPrompt();
            DisplayPrompt();
            GetRandomQuestion();
            DisplayQuestion();
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }

        DisplayEndingMessage();
        ShowCountDown(_duration * 60);
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int promptIndex = random.Next(0, _prompts.Count);
        return _prompts[promptIndex];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int questionIndex = random.Next(0, _questions.Count);
        return _questions[questionIndex];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine("Prompt: " + GetRandomPrompt());
        Console.WriteLine("Please take a moment to reflect on your thoughts and feelings.");
    }

    public void DisplayQuestion()
    {
        Console.WriteLine("Question: " + GetRandomQuestion());
        Console.WriteLine("Please respond with your thoughts.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
         ListingActivity listingActivity = new ListingActivity();
         listingActivity.Run();

         BreathingActivity breathingActivity = new BreathingActivity();
         breathingActivity.Run();

         ReflectingActivity reflectingActivity = new ReflectingActivity();
         reflectingActivity.Run();

        
         Console.ReadLine();
     }
}