using System;
using System.Collections.Generic;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parking = new Dictionary<string, string>();
            int commandCount = int.Parse(Console.ReadLine());
            for(int i = 0; i < commandCount; i++)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "register")
                {
                    if (!parking.ContainsKey(command[1]))
                    {
                        parking.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {command[2]} successfully");
                        continue;
                    }
                    Console.WriteLine($"ERROR: already registered with plate number {parking[command[1]]}");
                }
                else if (command[0] == "unregister")
                {
                    if (!parking.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                        continue;
                    }
                    parking.Remove(command[1]);
                    Console.WriteLine($"{command[1]} unregistered successfully");
                }
            }
            foreach(KeyValuePair<string, string> user in parking)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
