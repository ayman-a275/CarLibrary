namespace CarLibrary
{
    public abstract class Car : IDrivable
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int Odometer { get; set; }
        public bool IsEngineRunning { get; set; }
        public double EnergyLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MaxEnergy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Car(string brand, string model, string licensePlate, int odometer, bool isEngineRunning)
        {
            Brand = brand;
            Model = model;
            LicensePlate = licensePlate;
            Odometer = odometer;
            IsEngineRunning = isEngineRunning;
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
