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