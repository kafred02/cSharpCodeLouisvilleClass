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


            //

            EnergyCalculator ec = new EnergyCalculator();
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "EnergyUsage.csv");
            var fileContents = ReadEnergyResults(fileName);
            var fileEnergyResults = Path.Combine(directory.FullName, "fileEnergyResults.csv");


            //starts the console:

            // Display title as the C# console calculator app
            Console.WriteLine("Welcome to the Energy Calculator\r");
            Console.WriteLine("------------------------\n");
            Console.WriteLine("Please press any key");
            Console.ReadKey();
            MainMenu();

            //Displays the main menu and rus the MainMenu based on the information the user utilizes.  
            void MainMenu()
            {
                Console.WriteLine("");
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Calculate Energy Usage");
                Console.WriteLine("2. Add Energy Usage");
                Console.WriteLine("3. Run CSV File with Energy Usage");
                Console.WriteLine("4. Exit");


                var ans = Console.ReadLine();

                int choice = 0;

                if (int.TryParse(ans, out choice))

                {
                    switch (choice)

                    {
                        //calculates the energy usage based on the input
                        case 1:
                            Console.WriteLine("Please type an energy usage");
                            
                            
                            //Console.Write() = 
                            break;
                        //something for option 1
                        //add usage to the csv file and calculate usage
                        case 2:
                            AddUsage();
                            MainMenu();
                            break;
                        //something for option 2


                        //runs the usage in the 
                        case 3:
                            RunUsage();
                            MainMenu();
                            break;
                        //something for option 3

                        case 4:
                            System.Environment.Exit(1);
                            break;

                        default:

                            Console.WriteLine("Wrong selection!" +

                          Environment.NewLine + "Press any key for exit");

                            Console.ReadKey();

                            MainMenu();
                            break;

                    }

                }

                else

                {
                    //if nothing is entered then this is prompted to the user.
                    Console.WriteLine("You must type numeric value only!" +

                    Environment.NewLine + "Press any kay for exit");

                    Console.ReadKey();

                }

            }

           

            // Add usage to the csv file based on the inputs from the user.
            void AddUsage()
            {

                StreamWriter file2 = new StreamWriter(fileName, true);
                Console.WriteLine("Please type in a first name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Please type in a last name");
                string lastName = Console.ReadLine();
                Console.WriteLine("Please type in a date (MM/DD/YYYY)");
                var Month = Console.ReadLine();
                Console.WriteLine("Please type in an energy Usage");
                string addEnergy = Console.ReadLine();


                file2.WriteLine("" + firstName + "," + lastName + "," + Month + "," + addEnergy + "");
                //file2.File.AppendAllText(newFileName, "text");
                //file2.Appendtext("text name");
                file2.Close();

                //using (var newline = new StreamWriter(fileName));
                //{
                //    List<string> newLines = new List<string>();
                //    newLines.Add("this is the new line....");

                //    File.AppendAllLines("fileName", newLines);
                //}
            }


            // Runs the csv file to calculates column 4 the energy usage column, and populates the console with the results.
             void RunUsage(){
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
                Console.WriteLine("Press any key to go back to the main menu");
                Console.ReadKey();
                MainMenu();
                //
            }
        }

        void EnergyUsageCalculator(int energyUsage) {


        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        // reads the csv file from column 3 of the energyusage file.
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

