using System;
using System.Collections.Generic;
using System.Text;

//Ths is the class that calculates energy usage based on the energyUsage from the CSV file, or the inputted file.

namespace ConsoleApp3
{
   public class EnergyCalculator
    {
        public double Usage { get; set; }
        private double CustomerCharge => 20;
        private double EnergyCharge => .05;
        private double EnergyEffiencyCharge => .01;
        private double ECA => .01;
        

        public double EnergyChargeCost => EnergyCharge * Usage;
        public double EnergyEffiencyChargeCost => EnergyEffiencyCharge * Usage;
        public double CustomerChargeCost => CustomerCharge;
        public double ECACost => ECA * Usage;

        public double TotalCost => EnergyChargeCost + EnergyEffiencyChargeCost + CustomerChargeCost + ECACost;

        



    }
    
}
