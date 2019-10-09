using System;

namespace APG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Generator generator = new Generator();
            
            Console.Write("Enter the keyword: ");
            string keyword = Console.ReadLine();
            
            Console.Write("Enter the domain of the site: ");
            string domain = Console.ReadLine();
            
            Console.Write("Add a special symbol? Yes or no: ");
            string symbol = Console.ReadLine();

            Console.Write($"Your password: {generator.Start(keyword, domain, symbol)}");
        }
    }
}