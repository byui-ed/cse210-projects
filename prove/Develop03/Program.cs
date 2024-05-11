using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureHider
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16");
            ClearConsole();
            DisplayScripture(scripture);
            while (true)
            {
                Console.WriteLine("Press Enter to hide a word, type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                HideWord(scripture);
                ClearConsole();
                DisplayScripture(scripture);
            }
        }

        static void ClearConsole()
        {
            Console.Clear();
        }

        static void DisplayScripture(Scripture scripture)
        {
            Console.WriteLine(scripture.Reference);
            Console.WriteLine(scripture.Text);
        }

        static void HideWord(Scripture scripture)
        {
            if (scripture.HiddenWords.Count >= scripture.Text.Split(' ').Length)
            {
                return;
            }
            Random random = new Random();
            List<string> words = scripture.Text.Split(' ').ToList();
            while (true)
            {
                int index = random.Next(0, words.Count);
                if (!scripture.HiddenWords.Contains(words[index]))
                {
                    words[index] = "[HIDDEN]";
                    scripture.HiddenWords.Add(words[index]);
                    break;
                }
            }
            scripture.Text = string.Join(" ", words);
        }
    }

    class ScriptureReference
    {
        public string Book { get; set; }
        public string Verse { get; set; }
        public string Range { get; set; }

        public ScriptureReference(string verse)
        {
            if (verse.Contains('-'))
            {
                string[] parts = verse.Split('-');
                Book = parts[0].Trim();
                Range = "-" + parts[1].Trim();
                Verse = null;
            }
            else
            {
                Book = verse.Trim();
                Range = null;
                Verse = null;
            }
        }

        public override string ToString()
        {
            if (Range != null)
            {
                return Book + " " + Range;
            }
            else
            {
                return Book + " " + Verse;
            }
        }
    }

    class Scripture
    {
        public ScriptureReference Reference { get; set; }
        public string Text { get; set; }
        public List<string> HiddenWords { get; set; } = new List<string>();

        public Scripture(string verse)
        {
            Reference = new ScriptureReference(verse);
            LoadText();
        }

        private void LoadText()
        {
            // Load the text from a file or database
            // For this example, just use a hardcoded text
            Text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life. For God did not send his Son into the world to condemn the world, but to save the world through him.";
        }
    }

    class Word
    {
        // You could add properties and methods to this class if needed
    }
}