namespace CarLibrary
{
    public interface IDrivable
    {
        public void StartEngine();
        public void StopEngine();
        public void Drive(double km);
        public bool CanDrive(double km);
    }
}