using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentAcademy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();
            int numOfCommands = int.Parse(Console.ReadLine());
            for(int i = 0; i < numOfCommands; i++)
            {
                string currStudent = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(currStudent))
                {
                    students.Add(currStudent, new List<double>());
                }
                students[currStudent].Add(grade);
            }

            foreach(KeyValuePair<string, List<double>> kvp in students.Where(x=> x.Value.Average() >= 4.50))
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value.Average():f2}");
            } 
        }
      
    }
}
