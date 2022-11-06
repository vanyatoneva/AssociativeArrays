using System;
using System.Collections.Generic;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command;
            while((command = Console.ReadLine()) != "end")
            {
                string[] info = command.Split(" : ");
                string course = info[0];
                string student = info[1];
                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(student);
            }
            foreach(KeyValuePair<string, List<string>> kvp in courses)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");
                foreach(string stud in kvp.Value)
                {
                    Console.WriteLine($"-- {stud}");
                }
            }
        }
    }
}
