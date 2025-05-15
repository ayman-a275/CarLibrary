using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class FuelCar : Car, IEnergy
    {
        
        public double EnergyLevel { get; set; }
        public double MaxEnergy { get; set; }
        public double KmPerLiter { get; set; }

        public FuelCar(string brand, string model, string licensePlate, int odometer, bool isEngineRunning, double energyLevel, double maxEnergy, double kmPerLiter) : base(brand, model, licensePlate, odometer, isEngineRunning)
        {
            EnergyLevel = energyLevel;
            MaxEnergy = maxEnergy;
            KmPerLiter = kmPerLiter;
        }

        public void Refill(double amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "Refill amount must be positive.");
            EnergyLevel = Math.Min(EnergyLevel + amount, MaxEnergy);
        }
        

        public void UseEnergy(double km)
        {
            if (km < 0) throw new ArgumentOutOfRangeException(nameof(km), "Distance must be positive.");
            double energyUsed = CalculateEnergyUsed(km);
            EnergyLevel = Math.Max(EnergyLevel - energyUsed, 0);
        }

        public double CalculateEnergyUsed(double km)
        {
            // Check if the car can drive the requested distance  
            if (!CanDrive(km))
                throw new InvalidOperationException("Cannot drive the requested distance.");

            // Calculate energy used based on distance and fuel efficiency  
            double energyUsed = km / KmPerLiter;

            return energyUsed;
        }

        

        public override void Drive(double km)
        {
            if (!CanDrive(km))
                throw new InvalidOperationException("Cannot drive the requested distance.");

            Odometer += (int)km;
            UseEnergy(km);
        }
        public override bool CanDrive(double km)
        {
            //Tjek om motoren er tændt, om der er nok energy til distancen, hvis ja så kan turen gennemføres
            if (km <= 0) return false;
            if (!IsEngineRunning) return false;

            double requiredEnergy = CalculateEnergyUsed(km);
            return EnergyLevel >= requiredEnergy;
        }


    }
}
