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
        private static readonly Queue<Patient> stationOne = new();
        private static readonly Queue<Patient> stationTwo = new();
        private static readonly Queue<Patient> stationThree = new();
        private static readonly Queue<Patient> stationFour = new();

        static void Main(string[] args)
        {
            int screened = (60 / 2) * 8;
            for (int i = 0; i < screened; i++)
            {
                stationOne.Enqueue(new Patient { Name = RandomString(5) });
                stationTwo.Enqueue(new Patient { Name = RandomString(5) });
                stationThree.Enqueue(new Patient { Name = RandomString(5) });

                if (i == 20)
                {
                    Console.WriteLine($"20th Patient has been reached in {i * 2} minutes");
                }
            }
            Console.WriteLine($"Total People Screen in all 3 stations: {stationOne.Count + stationTwo.Count + stationThree.Count} after 8 hours");

            int vaccinated = (60 / 12) * 8;
            for (int i = 0; i < vaccinated; i++)
            {
                stationOne.Dequeue();
                stationTwo.Dequeue();
                stationThree.Dequeue();
            }

            Console.WriteLine($"People still left in station One: {stationOne.Count}");
            Console.WriteLine($"People still left in station Two: {stationTwo.Count}");
            Console.WriteLine($"People still left in station Three: {stationTwo.Count}");
            Console.WriteLine($"People still left in total: {stationOne.Count + stationTwo.Count + stationThree.Count} after 8 hours");


            Console.WriteLine($"If another station was added { vaccinated } more people would be vaccinated.\nLeaving the total count left to be vaccinated in the queues as {stationOne.Count + stationTwo.Count + stationThree.Count - vaccinated}");

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
