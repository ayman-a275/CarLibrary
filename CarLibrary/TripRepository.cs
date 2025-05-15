using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class TripRepository : ITripRepository
    {
        public List<Trip> trips = new List<Trip>();
        public void AddTrip(Trip trip)
        {
            trips.Add(trip);
        }

        public void DeleteTrip(Trip trip)
        {
            trips.RemoveAll(t => t.Car.LicensePlate == trip.Car.LicensePlate);
        }

        public List<Trip> GetTripsForCar(string regNr)
        {
            return trips.Where(t => t.Car.LicensePlate == regNr).ToList();
        }
    }
}
