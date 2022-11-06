using System;
using System.Collections.Generic;

namespace AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string command;
            while((command = Console.ReadLine()) != "stop")
            {
                int qty = int.Parse(Console.ReadLine());
                if (!resources.ContainsKey(command))
                {
                    resources.Add(command, 0);
                }
                resources[command] += qty;
            }
            foreach(KeyValuePair<string, int> kvp in resources)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
