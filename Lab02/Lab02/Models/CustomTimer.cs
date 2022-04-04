using System;
using System.Diagnostics;
namespace Lab02.Models
{
    public class CustomTimer
    {
        Stopwatch timer;
        
        public void Start()
        {
            timer = new Stopwatch();
            timer.Start();
        }
        public void Stop() 
        { 
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
        }

    }
}
