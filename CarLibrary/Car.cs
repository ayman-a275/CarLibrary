using Microsoft.VisualBasic.FileIO;
using System.Drawing;

namespace CarLibrary
{
    public abstract class Car : IDrivable
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int Odometer { get; set; }
        public bool IsEngineRunning { get; set; }

        public Car(string brand, string model, string licensePlate, int odometer)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Odometer = odometer;
            IsEngineRunning = false;
        }

        public void StartEngine()
        {
            IsEngineRunning = true;
        }

        public void StopEngine()
        {
            IsEngineRunning = false;
        }

        public abstract void Drive(double km);

        public abstract bool CanDrive(double km);
    }
}
