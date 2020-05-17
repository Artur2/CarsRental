using System.Collections.Generic;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;

namespace CarsRental.Domain.Cars.Seeds
{
    /// <summary>
    /// Seed data for <see cref="Vans"/>
    /// </summary>
    public class VansSeedData : ISeedData<Vans>
    {
        public IEnumerable<Vans> GetData()
        {
            yield return new Vans
            {
                Id = 27,
                Title = "Chevrolet Express 2500",
                Price = 3000,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 140 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };

            yield return new Vans
            {
                Id = 28,
                Title = "Chrysler Pacifica",
                Price = 1500,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 140 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };

            yield return new Vans
            {
                Id = 29,
                Title = "Honda Odyssey",
                Price = 1600,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 160 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };

            yield return new Vans
            {
                Id = 30,
                Title = "Mercedes-Benz Metris",
                Price = 1800,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 160 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };

            yield return new Vans
            {
                Id = 31,
                Title = "Ford Transit Connect",
                Price = 3100,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 160 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" },
                IsRented = true
            };

            yield return new Vans
            {
                Id = 32,
                Title = "Ford Transit",
                Price = 2800,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 160 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" },
                IsRented = true
            };

            yield return new Vans
            {
                Id = 33,
                Title = "Mercedes-Benz Sprinter",
                Price = 3000,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 170 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };

            yield return new Vans
            {
                Id = 34,
                Title = "Toyota Sienna",
                Price = 2250,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 160 },
                Stereo = new CarStereo { IsWorkingWell = true, Title = "Stock" }
            };
        }
    }
}
