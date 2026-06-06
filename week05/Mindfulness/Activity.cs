using System;
using System.Threading;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    protected string Name => _name;
    protected string Description => _description;
    protected int Duration => _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        DisplayStartingMessage();
        RunActivity();
        DisplayEndingMessage();
    }

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Mindfulness Activity.");
        Console.WriteLine(_description);
        Console.Write("Please enter the duration in seconds: ");
        
        if (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid duration. Defaulting to 30 seconds.");
            _duration = 30;
        }

        Console.WriteLine("Prepare to begin...");
        DisplayAnimation(5);
    }

    private void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        DisplayAnimation(3);
        Console.WriteLine($"You have completed the {_name} activity for {_duration} seconds.");
        DisplayAnimation(3);
    }

    protected void DisplayAnimation(int seconds)
    {
        string[] spinChars = { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        int spinIndex = 0;
        
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            Console.Write($"\r{spinChars[spinIndex]} Pausing... ");
            spinIndex = (spinIndex + 1) % spinChars.Length;
            Thread.Sleep(100);
        }
        Console.WriteLine("\rDone!                              ");
    }

    protected abstract void RunActivity();
}
