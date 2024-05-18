public class Activity
{
    public string _name;
    public string _description;
    public int _duration;

    public Activity()
    {
        // Initialize any default values or perform any necessary setup
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine("Starting activity: " + _name);
        // Additional code to display the starting message
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Ending activity: " + _name);
        // Additional code to display the ending message
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i >= 0; i--)
        {
            Console.WriteLine("Time remaining: " + i + " seconds");
            System.Threading.Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine("Time's up!");
    }
}