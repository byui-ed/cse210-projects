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