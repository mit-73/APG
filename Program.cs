using System;

namespace APG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Generator generator = new Generator();

            Console.WriteLine("Algorithmic Password Generation");

            if (args.Length == 0)
            {
                Run(generator);
            }
            else
            {
                RunWithArgs(generator, args);
            }

            Console.ReadLine();
        }


        public static void Run(Generator generator)
        {
            Console.Write("Enter the keyword: ");
            string keyword = Console.ReadLine();
            
            Console.Write("Enter the domain of the site: ");
            string domain = Console.ReadLine();
            
            Console.Write("Enter the special symbol ((( ! \" # $ % & \' ( ) * + , - . / : ; < = > ? @ [ \\ ] ^ _` { | } ~ Null )))‎:");
            string symbol = Console.ReadLine();
            
            Console.Write($"Your password: {generator.Start(keyword, domain, symbol)}");
        }

        public static void RunWithArgs(Generator generator, string[] args)
        {
            string keyword = null, domain = null, symbol = "yes";
            
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-keyword")
                {
                    keyword = args[i + 1];
                    Console.WriteLine($"Keyword: {keyword}");
                    continue;
                }
                
                if (args[i] == "-domain")
                {
                    domain = args[i + 1];
                    Console.WriteLine($"Domain: {domain}");
                    continue;
                }
                
                if (args[i] == "-symbol")
                {
                    symbol = args[i + 1];
                    Console.WriteLine($"Special symbol: {symbol}");
                    continue;
                }
            }

            if (keyword != null && domain != null)
                Console.WriteLine($"Your password: {generator.Start(keyword, domain, symbol)}");
            else Console.WriteLine($"Keyword or Domain equals Null");
        }
    }
}