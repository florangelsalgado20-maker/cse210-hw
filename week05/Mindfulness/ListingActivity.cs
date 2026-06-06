using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private static readonly Random _random = new Random();

    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<int> _usedPromptIndices = new List<int>();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void RunActivity()
    {
        string prompt = GetUniqueRandom(_prompts, _usedPromptIndices);
        Console.WriteLine(prompt);
        
        Console.WriteLine("Please take a moment to think about this...");
        DisplayAnimation(5);

        Console.WriteLine("Start listing items now! (Press Enter after each item)");
        int count = 0;
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                count++;
            }
            
            if ((DateTime.Now - startTime).TotalSeconds >= Duration)
            {
                break;
            }
        }

        Console.WriteLine($"You entered {count} items.");
    }

    private string GetUniqueRandom(List<string> list, List<int> usedIndices)
    {
        if (usedIndices.Count == list.Count)
        {
            usedIndices.Clear();
        }
        
        int index;
        do
        {
            index = _random.Next(list.Count);
        } while (usedIndices.Contains(index));
        
        usedIndices.Add(index);
        return list[index];
    }
}
