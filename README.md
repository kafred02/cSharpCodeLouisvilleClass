# cSharpCodeLouisvilleClass
This is my code louisville c# project

This application is built with Visual Studio, dotnet, and C#. The application prompts a basic options for the user to calculate their energy usage.  Once the user types in an energy usage, or adds an energy usage to the 'EnergyUsage.csv' file then it performs a calculation to get a total energy cost.

Energy Calculation:
Customer Charge: Fixed Charge of $20
EnergyCharge: EnergyUsage * .05
EnergyEfficiencyCharge: Energy Usage * .01
ECA: Energy Usage * .01.

Total Energy = CustomerCharge + EnergyCharge + EnergyEfficiencyCharge + ECA;

For example is Usage is 100 then the calculation will be $27.  

$20 + (100 * .05) + (100 * .01) + (100 * .01) = $27

Main Menu:

1. Calculate Energy Usage -> if the user wants to calculate one usage then they can type in a usage and perform a calculation.
2. Add Energy Usage -> prompts the user to types in a first name, last name, date (mm/dd/yyyy), and usage.  The information is then added to the 'EnergyUsage.csv' file.
3. Run CSV File with Energy Usage -> this runs the energy usage in column 4 of the 'EnergyUsage.csv' and writes the results to the 'fileEnergyResults.csv'.
4. Exit  -> exits the program.
