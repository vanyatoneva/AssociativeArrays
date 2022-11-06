using System;
using System.Collections.Generic;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
            string userInput;
            while((userInput = Console.ReadLine()) != "buy")
            {
                string[] prod = userInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string product = prod[0];
                double price = double.Parse(prod[1]);
                double quantity = double.Parse(prod[2]);
                if (!products.ContainsKey(product))
                {
                    products.Add(product, new double[2]);
                }
                products[product][0] = price;
                products[product][1] += quantity;
            }
            foreach(KeyValuePair<string, double[]> product in products)
            {
                Console.WriteLine($"{product.Key} -> {product.Value[0] * product.Value[1]:f2}");
            }
        }
    }
}
