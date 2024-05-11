using System.IO
using System.Collections.Generic;
public class Scripture
{
    private string reference;
    private string text;
    private List hiddenWords = new List();

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
    }

    public void Display()
    {
        string displayedText = text;
        foreach (var word in hiddenWords)
        {
            displayedText = displayedText.Replace(word, new string('_', word.Length));
        }
        Console.WriteLine($"{reference}: {displayedText}");
    }

    public bool HideRandomWord()
    {
        string[] words = text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        Random random = new Random();
        int randomIndex = random.Next(0, words.Length);

        string wordToHide = words[randomIndex];
        hiddenWords.Add(wordToHide);
        return hiddenWords.Count < words.Length;
    }

    public bool AllWordsHidden()
    {
        return hiddenWords.Count == text.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public class Program
{
    public static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his only Son");
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            scripture.Display();

            Console.WriteLine("\nPress Enter to continue, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (!scripture.HideRandomWord())
            {
                break;
            }
        }
    }
}
