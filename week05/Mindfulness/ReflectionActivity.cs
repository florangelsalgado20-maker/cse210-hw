using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private static readonly Random _random = new Random();
    
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<int> _usedPromptIndices = new List<int>();
    private List<int> _usedQuestionIndices = new List<int>();

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void RunActivity()
    {
        string prompt = GetUniqueRandom(_prompts, _usedPromptIndices);
        Console.WriteLine(prompt);
        DisplayAnimation(3);

        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            string question = GetUniqueRandom(_questions, _usedQuestionIndices);
            Console.WriteLine(question);
            DisplayAnimation(5);
        }
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
