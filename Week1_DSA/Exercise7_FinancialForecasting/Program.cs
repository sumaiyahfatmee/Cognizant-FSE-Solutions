
using System;

namespace Exercise7_FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentValue = 10000;
            double growthRate = 0.10;
            int years = 5;

            double futureValue = FinancialForecast.PredictFutureValue(currentValue, growthRate, years);

            Console.WriteLine("===== Financial Forecast =====");
            Console.WriteLine($"Current Value : {currentValue}");
            Console.WriteLine($"Growth Rate   : {growthRate * 100}%");
            Console.WriteLine($"Years         : {years}");
            Console.WriteLine($"Future Value  : {futureValue:F2}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}