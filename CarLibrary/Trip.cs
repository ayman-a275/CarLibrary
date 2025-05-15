using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class Trip
    {
        public double Distance { get; set; }
        public DateTime TripDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Car Car { get; set; }

        public Trip(double distance, DateTime tripDate, DateTime startTime, DateTime endTime, Car car)
        {
            Distance = distance;
            TripDate = tripDate;
            StartTime = startTime;
            EndTime = endTime;
            Car = car;
        }

        public TimeSpan CalculateDuration()
        {
            return EndTime - StartTime;
        }

        public double CalculateTripPrice(double energyUnitPrice)
        {
            return Distance * energyUnitPrice;
        }

        public void PrintTripDetails()
        {
            Console.WriteLine($@"Distance: {Distance}
Trip date: {TripDate}
Start time: {StartTime}
End time: {EndTime}
Bil: {Car.Brand} {Car.Model}");
        }
    }
}
