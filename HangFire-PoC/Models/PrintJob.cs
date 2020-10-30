namespace HangFire_PoC.Models
{
    using System;
    using Hangfire;

    [LogEverything]
    public class PrintJob : IPrintJob
    {
        [Queue("alpha")]
        [LogEverything]
        public void Print()
        {
            Console.WriteLine($"Hanfire recurring job!");
        }
    }
}
