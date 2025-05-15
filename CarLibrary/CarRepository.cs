using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public class CarRepository : ICarRepository
    {
        public List<Car>? cars;
        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        public void DeleteCar(string licensePlate)
        {
            cars.RemoveAll(c => c.LicensePlate == licensePlate);
        }

        public Car? FindByLicensePlate(string licensePlate)
        {
            return cars.FirstOrDefault(c => c.LicensePlate == licensePlate);
        }

        public List<Car> GetAllCars()
        {
            return cars;
        }
    }
}
