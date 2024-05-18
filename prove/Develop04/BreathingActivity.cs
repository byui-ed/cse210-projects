public class BreathingActivity : Activity
{
    public BreathingActivity() : base()
    {
        _name = "Breathing Activity";
        _description = "This activity involves breathing exercises to relax and focus.";
        _duration = 5; // Default duration in minutes
    }

    public override void Run()
    {
        Console.WriteLine("Starting Breathing Activity...");
        DisplayStartingMessage();

        // Run the activity
        for (int i = 0; i < _duration * 60; i++) // Loop for the duration in seconds
        {
            Console.WriteLine("Inhale...");
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds

            Console.WriteLine("Exhale...");
            System.Threading.Thread.Sleep(2000); // Wait for 2 seconds
        }

        DisplayEndingMessage();
        ShowCountDown(_duration * 60);
    }
}