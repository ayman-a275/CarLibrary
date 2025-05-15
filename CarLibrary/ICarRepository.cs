using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLibrary
{
    public interface ICarRepository
    {
        public List<Car> GetAllCars();
        public Car? FindByLicensePlate(string licensePlate);
        public void AddCar(Car car);
        public void DeleteCar(string licensePlate);
    }
}
