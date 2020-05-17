using System.Collections.Generic;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;

namespace CarsRental.Domain.Cars.Seeds
{
    /// <summary>
    /// Seed for <see cref="SportCar"/>
    /// </summary>
    public class SportCarSeedData : ISeedData<SportCar>
    {
        public IEnumerable<SportCar> GetData()
        {
            yield return new SportCar
            {
                Id = 14,
                Title = "Acura RSX",
                Price = 4000,
                Conditioner = new CarAirConditioner { Title = "Acura's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 280 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Pioneer", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 15,
                Title = "Mazda RX7",
                Price = 4300,
                Conditioner = new CarAirConditioner { Title = "Mazda's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = false, Speed = 280 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 16,
                Title = "Mazda RX7",
                Price = 6000,
                Conditioner = new CarAirConditioner { Title = "Mazda's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 280 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Pioneer", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 17,
                Title = "Nissan Skyline",
                Price = 6500,
                Conditioner = new CarAirConditioner { Title = "Nissans's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 280 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 18,
                Title = "Opel Omega",
                Price = 8000,
                Conditioner = new CarAirConditioner { Title = "Opel's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 280 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 19,
                Title = "Subaru WRX STi",
                Price = 7500,
                Conditioner = new CarAirConditioner { Title = "Opel's Conditioner", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 280 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 20,
                Title = "Lamborghini Aventador S",
                Price = 9000,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 320 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 21,
                Title = "Lamborghini Aventador SVJ",
                Price = 9000,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 320 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 22,
                Title = "Lamborghini Aventador SVJ",
                Price = 9000,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 320 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 23,
                Title = "Mazda MX-5",
                Price = 4500,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 260 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 24,
                Title = "Mazda MX-5",
                Price = 4500,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 260 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 25,
                Title = "Ferrari F8 Spider",
                Price = 9300,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 320 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new SportCar
            {
                Id = 26,
                Title = "Ferrari F8 Spider",
                Price = 8600,
                Conditioner = new CarAirConditioner { Title = "Stock", IsWorkingWell = true },
                Engine = new CarEngine { IsWorkingWell = false, Speed = 320 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };
        }
    }
}
