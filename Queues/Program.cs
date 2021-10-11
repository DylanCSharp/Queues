using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Queues
{
    class Program
    {

        private static readonly Random random = new();
        private static readonly Queue<Patient> screenStation = new();
        private static readonly Queue<Patient> stationOne = new();
        private static readonly Queue<Patient> stationTwo = new();
        private static readonly Queue<Patient> stationThree = new();

        static void Main(string[] args)
        {
            int screened = (60 / 2) * 8;
            for (int i = 0; i < screened; i++)
            {
                screenStation.Enqueue(new Patient { Name = RandomString(5) });
                
            }
            Console.WriteLine($"Total People Screen in 8 hours: {screenStation.Count} after 8 hours");

            int vaccinated = (60 / 12) * 3 * 8;
            for (int i = 0; i < vaccinated; i++)
            {
                screenStation.Dequeue();

                if (i == 20)
                {
                    Console.WriteLine($"The 20th person has been reached in {i * 12 / 3} minutes");
                }
            }

            Console.WriteLine($"Total People Vaccinated in 8 hours: {screenStation.Count}");
            int extraStation = (60 / 12) * 8;
            Console.WriteLine($"If another station was added { extraStation } more people would be vaccinated.\nLeaving the total count left to be vaccinated in the queues as {screenStation.Count - extraStation}");
            Console.WriteLine($"If there was a 4th station the 20th patient would be reached in {20 * 12 / 4} minutes");
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
