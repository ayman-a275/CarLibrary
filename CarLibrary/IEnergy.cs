namespace CarLibrary
{
    public interface IEnergy
    {
        public double EnergyLevel { get; set; }
        public double MaxEnergy { get; set; }

        public void Refill(double amount);
        public void UseEnergy(double km);
        public double CalculateEnergyUsed(double km);
    }
}