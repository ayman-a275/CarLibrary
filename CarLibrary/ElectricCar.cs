using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class ElectricCar : Car, IEnergy
    {
        public double EnergyLevel { get; set; }
        public double MaxEnergy { get; set; }
        public double KmPerKwh { get; set; }

        public ElectricCar(string brand, string model, string licensePlate, int odometer, double energyLevel, double maxEnergy, double kmPerKwh) : base(brand, model, licensePlate, odometer)
        {
            EnergyLevel = energyLevel;
            MaxEnergy = maxEnergy;
            KmPerKwh = kmPerKwh;
        }

        public double CalculateEnergyUsed(double km)
        {
            return km / KmPerKwh;
        }

        public override bool CanDrive(double km)
        {
            if (!IsEngineRunning || CalculateEnergyUsed(km) >= EnergyLevel)
                return false;

            return true;
        }

        public override void Drive(double km)
        {
            if (!CanDrive(km))
            {
                Console.WriteLine("Du kan ikke køre");
                return;
            }
                

            UseEnergy(km);
            Odometer += (int)km;
        }

        public void Refill(double amount)
        {
            if (EnergyLevel + amount > MaxEnergy)
                EnergyLevel = MaxEnergy;

            EnergyLevel += amount;
        }

        public void UseEnergy(double km)
        {
            EnergyLevel -= CalculateEnergyUsed(km);
        }
    }
}
