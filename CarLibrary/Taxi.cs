using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class Taxi : Car, IEnergy
    {
        private bool MeterStarted { get; set; }
        public double StartPrice { get; set; }
        public double PricePerKm { get; set; }
        public double PricePerMinut { get; set; }
        public double EnergyLevel { get; set; }
        public double MaxEnergy { get; set; }

        public Taxi(string brand, string model, string licensePlate, int odometer, bool meterStarted, double startPrice, double pricePerKm, double energyLevel, double maxEnergy)
            : base(brand, model, licensePlate, odometer)
        {
            MeterStarted = meterStarted;
            StartPrice = startPrice;
            PricePerKm = pricePerKm;
            EnergyLevel = energyLevel;
            MaxEnergy = maxEnergy;
        }
        public void StartMeter()
        {
            MeterStarted = true;
        }
        public void StopMeter()
        {
            MeterStarted = false;
        }

        public double CalculateFare(double km, double minutes)
        {
            return StartPrice + (PricePerKm * km) + (PricePerMinut * minutes);
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

        public override void Drive(double km)
        {
            
            // Tjek om motoren er tændt, om der er nok energy. Opdater odometer efter tur og træk distancen fra i EnergyLevel
           if (!CanDrive(km)) throw new NotImplementedException("Cannot drive the requested distance");

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

        public double CalculateEnergyUsed(double km)
        {
            return km;
        }

    }
}
