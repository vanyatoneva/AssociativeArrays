using System;
using System.Collections.Generic;
using System.Linq;

namespace CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] textArray = Console.ReadLine().
                ToCharArray();
                
            Dictionary<char, int> charsCount = new Dictionary<char, int>();
            for (int i = 0; i < textArray.Length; i++)
            {
                if (textArray[i] != ' ')
                {
                    if (!charsCount.ContainsKey(textArray[i]))
                    {
                        charsCount.Add(textArray[i], 0);
                    }
                    charsCount[textArray[i]]++;
                }
            }
            foreach(var kvp in charsCount)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
