using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            EnergyCalculator ec = new EnergyCalculator();
            Console.WriteLine("What is your monthly usage?");
            ec.Usage = double.Parse(Console.ReadLine());
            Console.WriteLine("Your total cost is " + ec.TotalCost);
            Console.ReadKey();

           
        }
    }
}


