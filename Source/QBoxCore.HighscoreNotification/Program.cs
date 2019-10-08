using System;
using System.Threading;

namespace QBoxCore.HighscoreNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Waiting for highscore notifications");

            while(true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
