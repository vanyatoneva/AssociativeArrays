using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();
            string comm;
            while ((comm = Console.ReadLine()) != "end of contests")
            {
                string[] contest = comm.Split(":");
                if (!contests.ContainsKey(contest[0]))
                {
                    contests.Add(contest[0], contest[1]);
                }
            }
            while ((comm = Console.ReadLine()) != "end of submissions")
            {
                string[] userPoints = comm.Split("=>");
                if(contests.ContainsKey(userPoints[0]) && contests[userPoints[0]] == userPoints[1])
                {
                    if (!students.ContainsKey(userPoints[2]))
                    {
                        students.Add(userPoints[2], new Dictionary<string, int>());
                    }
                    if (!students[userPoints[2]].ContainsKey(userPoints[0])){
                        students[userPoints[2]].Add(userPoints[0], 0);
                    }
                    if (int.Parse(userPoints[3]) > students[userPoints[2]][userPoints[0]])
                    {
                        students[userPoints[2]][userPoints[0]] = int.Parse(userPoints[3]);
                    }
                }
            }
            PrintBestStudent(students);
            Console.WriteLine("Ranking: ");
            foreach(var student in students.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var contestPoints in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contestPoints.Key} -> {contestPoints.Value}");
                }
            }

        }

        public static void PrintBestStudent(Dictionary<string, Dictionary<string, int>> students)
        {
            int maxPoints = 0;
            string student = "";
            foreach(var kvp in students)
            {
                Dictionary<string, int> currentStudentPoints = kvp.Value;
                int totalPointsCurrStudent = currentStudentPoints.Values.Sum();
                if(totalPointsCurrStudent > maxPoints)
                {
                    maxPoints = totalPointsCurrStudent;
                    student = kvp.Key;
                }
            }
            Console.WriteLine($"Best candidate is {student} with total {maxPoints} points.");
        }
    }

    
}
