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
            //  var test = loadCsvFile();
            foreach (var energyUsage in fileContents)
            {
                ec.Usage = energyUsage.EnergyUsage;
                Console.WriteLine(ec.TotalCost);
                

            }
            Console.ReadKey();





            //Console.WriteLine("What is your monthly usage?");
            //ec.Usage = double.Parse(Console.ReadLine());
            //Console.WriteLine("Your total cost is " + ec.TotalCost);
            //Console.ReadKey();


            //Basic way to pull information 
            //System.IO.File.ReadAllLines ("file.csv")


        }

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


