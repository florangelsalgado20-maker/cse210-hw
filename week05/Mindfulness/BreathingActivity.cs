using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void RunActivity()
    {
        DateTime startTime = DateTime.Now;
        bool breatheIn = true;

        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            if (breatheIn)
            {
                Console.WriteLine("Breathe in...");
                DisplayBreathingAnimation(4, true);
            }
            else
            {
                Console.WriteLine("Breathe out...");
                DisplayBreathingAnimation(4, false);
            }
            
            breatheIn = !breatheIn;
        }
    }

    private void DisplayBreathingAnimation(int seconds, bool isInhaling)
    {
        DateTime startTime = DateTime.Now;
        string baseText = isInhaling ? "Breathe in" : "Breathe out";
        
        while ((DateTime.Now - startTime).TotalSeconds < seconds)
        {
            double elapsed = (DateTime.Now - startTime).TotalSeconds;
            double progress = elapsed / seconds;
            
            int length = (int)(progress * 20);
            if (!isInhaling)
            {
                length = 20 - length;
            }
            
            string bar = new string('*', length);
            Console.Write($"\r{baseText} [{bar,-20}] ");
            Thread.Sleep(100);
        }
        Console.WriteLine("\rDone!                              ");
    }
}
