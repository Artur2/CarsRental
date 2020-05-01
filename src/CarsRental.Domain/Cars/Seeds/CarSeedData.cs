using System.Collections.Generic;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;

namespace CarsRental.Domain.Cars.Seeds
{
    public class CarSeedData : ISeedData<Car>
    {
        public IEnumerable<Car> GetData()
        {
            yield return new Car
            {
                Id = 1,
                Conditioner = new CarAirConditioner { Title = "Test conditioner", IsWorkingWell = true },
                Title = "Test car",
                Price = 100.50f,
                Stereo = new CarStereo { Title = "Test stereo", IsWorkingWell = true },
                Engine = new CarEngine { Speed = 150, IsWorkingWell = true },
                IsRented = false
            };
        }
    }
}
