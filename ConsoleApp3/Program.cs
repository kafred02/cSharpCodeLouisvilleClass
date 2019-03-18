using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Would you like to 1: calculate a file 2: calcu");
           //https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo?view=netframework-4.7.2


            EnergyCalculator ec = new EnergyCalculator();
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "EnergyUsage.csv");
            var fileContents = ReadEnergyResults(fileName);
            var fileEnergyResults = Path.Combine(directory.FullName, "fileEnergyResults.csv");



            //start the console:

            // Display title as the C# console calculator app
            Console.WriteLine("Welcome to the Energy Calculator\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Please press any key");
            Console.ReadKey();

            //int userInput = 0;
            //do
            //{
            //    Console.Write() = int UserInput = 0;
            //    userInput = MainMenu();
            //} while (userInput != 5);

            //char choice;

            //for (;; )
            //{
            //    do
            //    {
            //        MainMenu();
            //        do
            //        {
            //            choice = (char)Console.Read();
            //        } while (choice == '\n' | choice == '\r');
            //    } while (choice < '1' | choice > '8' & choice != 'q');

            //    if (choice == 'q') break;

            //    Console.WriteLine("\n");


                using (var w = new StreamWriter(fileEnergyResults))
            {
                //check to see if file exist
                if (!File.Exists(fileEnergyResults))
                {
                    using (var stream = File.Create(fileEnergyResults)) { }

                }

                foreach (var energyUsage in fileContents)
                {
                    ec.Usage = energyUsage.EnergyUsage;
                    double WUsage = ec.Usage;
                    double WTotal = ec.TotalCost;

                    string csvRow = string.Format("{0},{1}", WUsage, WTotal);
                    w.WriteLine(csvRow);
                    //w.WriteLine(ec.TotalCost);
                    w.Flush();

                    Console.WriteLine(ec.TotalCost);


                }
            }

            Console.ReadKey();


        }

        public static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("--------------------");
            Console.WriteLine("[1] Calculate Energy Usage");
            Console.WriteLine("[2] Add Energy Usage to CSV file");
            Console.WriteLine("[3] Calculate ");
            Console.WriteLine("[4] Exit the program");
            Console.WriteLine("--------------------\n");
            Console.WriteLine("Please select an option from 1-4\n");

            string choice = Console.ReadLine();
            int number;
            bool result = Int32.TryParse(choice, out number);
            if (result)
            {
                Console.Clear();
               // SubMenu(number);
            }
            else
            {
                Console.WriteLine("Incorrect choice");
            }
        }



        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }


        public static List<EnergyUsageProfile> ReadEnergyResults(string fileName)
        {
            var energyResults = new List<EnergyUsageProfile>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var energyResult = new EnergyUsageProfile();
                    string[] values = line.Split(',');

                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        energyResult.EnergyUsage = parseInt;
                    }
                    energyResults.Add(energyResult);
                }
            }
            return energyResults;
        }

    }
}

//Console.WriteLine("What is your monthly usage?");
//ec.Usage = double.Parse(Console.ReadLine());
//Console.WriteLine("Your total cost is " + ec.TotalCost);
//Console.ReadKey();


//Basic way to pull information 
//System.IO.File.ReadAllLines ("file.csv")

//public static List<string> loadCsvFile()
//{
//    var reader = new StreamReader(File.OpenRead("C:\\Users\\elek0\\source\\repos\\cSharpCodeLouisvilleClass\\ConsoleApp3\\EnergyUsage.csv"));
//    List<string> searchList = new List<string>();
//    while (!reader.EndOfStream)
//    {
//        var line = reader.ReadLine();
//        searchList.Add(line);
//    }
//    return searchList;
//}