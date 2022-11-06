using System;
using System.Collections.Generic;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] userInfo = command.Split(" -> ");
                string company = userInfo[0];
                string user = userInfo[1];
                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                }
                if (!companies[company].Contains(user))
                {
                    companies[company].Add(user);
                }
            }
            foreach(var userId in companies)
            {
                Console.WriteLine(userId.Key);
                foreach(string currUser in userId.Value)
                {
                    Console.WriteLine($"-- {currUser}");
                }
            }
        }
    }
}
