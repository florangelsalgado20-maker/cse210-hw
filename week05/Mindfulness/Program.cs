/*
 * W05 Project: Mindfulness Program
 * Student: [Tu Nombre]
 * Course: CSE 210
 * 
 * Exceeding Requirements:
 * 1. Added a logging mechanism to track the frequency of each activity performed by the user.
 * 2. Implemented file I/O to save and load the activity log, ensuring data persistence between sessions.
 * 3. Ensured that random prompts and questions are not repeated until all options in their respective 
 *    lists have been utilized at least once during a single session.
 * 4. Enhanced the breathing activity with a custom visual animation (an expanding and contracting 
 *    progress bar) to provide a more meaningful and engaging breathing pace indicator.
 */

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> log = LoadLog();
        bool keepPlaying = true;

        while (keepPlaying)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an option (1-5): ");
            
            string choice = Console.ReadLine();
            Activity activity = null;
            string activityName = "";

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    activityName = "Breathing";
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    activityName = "Reflection";
                    break;
                case "3":
                    activity = new ListingActivity();
                    activityName = "Listing";
                    break;
                case "4":
                    DisplayLog(log);
                    continue;
                case "5":
                    keepPlaying = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    continue;
            }

            if (activity != null)
            {
                activity.Run();
                
                if (!log.ContainsKey(activityName))
                {
                    log[activityName] = 0;
                }
                log[activityName]++;
                SaveLog(log);

                Console.WriteLine("Press any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    static void DisplayLog(Dictionary<string, int> log)
    {
        Console.Clear();
        Console.WriteLine("--- Activity Log ---");
        if (log.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            foreach (var kvp in log)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} times");
            }
        }
        Console.WriteLine("--------------------");
        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    static Dictionary<string, int> LoadLog()
    {
        Dictionary<string, int> log = new Dictionary<string, int>();
        string filePath = "mindfulness_log.txt";
        
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int count))
                {
                    log[parts[0]] = count;
                }
            }
        }
        return log;
    }

    static void SaveLog(Dictionary<string, int> log)
    {
        string filePath = "mindfulness_log.txt";
        List<string> lines = new List<string>();
        
        foreach (var kvp in log)
        {
            lines.Add($"{kvp.Key},{kvp.Value}");
        }
        
        File.WriteAllLines(filePath, lines);
    }
}
