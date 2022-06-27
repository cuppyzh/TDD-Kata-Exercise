using Microsoft.Extensions.Logging;
using System;


namespace Cuppyzh.Exercise.TDD.Kata1
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });

            StringCalculator stringCalculator = new StringCalculator(loggerFactory.CreateLogger<StringCalculator>());
            stringCalculator.Add(args[0]);

            do
            {
                Console.WriteLine("Another input please: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                stringCalculator.Add(input);
            } while (true);
        }
    }
}
