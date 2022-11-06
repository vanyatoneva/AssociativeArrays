using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace DragonArmy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedDictionary<string, int[]>> dragonsByTypes = new Dictionary<string, SortedDictionary<string, int[]>>();
            int dragonsNum = int.Parse(Console.ReadLine());
            for(int i = 0; i < dragonsNum; i++)
            {
                string[] currDragon = Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    ToArray();
                string currType = currDragon[0];
                string currName = currDragon[1];
                int currDamage = (currDragon[2] == "null"? 45 : int.Parse(currDragon[2]));
                int currHealth = (currDragon[3] == "null" ? 250 : int.Parse(currDragon[3]));
                int currArmor = (currDragon[4] == "null" ? 10 : int.Parse(currDragon[4]));
             
                if (!dragonsByTypes.ContainsKey(currType))
                {
                    dragonsByTypes.Add(currType, new SortedDictionary<string, int[]>());
                }
                if (!dragonsByTypes[currType].ContainsKey(currName))
                {
                    dragonsByTypes[currType].Add(currName, new int[3]);
                }
                dragonsByTypes[currType][currName][0] = currDamage;
                dragonsByTypes[currType][currName][1] = currHealth;
                dragonsByTypes[currType][currName][2] = (currArmor);
            }

            foreach(var kvp in dragonsByTypes)
            {
                //Dictionary<string, List<int>> thisTypeDragons = kvp.Value;
                Console.WriteLine($"{kvp.Key}::({GetAverageProp(kvp.Value, "damage"):f2}/{GetAverageProp(kvp.Value, "health"):f2}/{GetAverageProp(kvp.Value, "armor"):f2})");
                foreach(var dragon in dragonsByTypes[kvp.Key])
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }

        public static double GetAverageProp(SortedDictionary<string, int[]> dragons, string prop)
        {
            double avr = 0.00;
            foreach(var kvp in dragons)
            {
                switch (prop)
                {
                    case "damage":
                        avr += kvp.Value[0];
                        break;
                    case "health":
                        avr += kvp.Value[1];
                        break;
                    case "armor":
                        avr += kvp.Value[2];
                        break;
                }
            }
            if(dragons.Values.Count > 0)
            {
                avr /= dragons.Values.Count;
            }
            return avr;
        }
    }
}
