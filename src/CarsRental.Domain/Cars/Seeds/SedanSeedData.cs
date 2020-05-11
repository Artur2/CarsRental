using System.Collections.Generic;
using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Data;

namespace CarsRental.Domain.Cars.Seeds
{
    public class SedanSeedData : ISeedData<Sedan>
    {
        public IEnumerable<Sedan> GetData()
        {
            yield return new Sedan
            {
                Price = 3000,
                Title = "Honda Accord",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Honda's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 250 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Pioneer", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2100,
                Title = "Opel Astra",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Opels's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 230 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2000,
                Title = "Ford Mondeo IV",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Fords's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 230 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2500,
                Title = "Honda Civic",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Hondas's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 245 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 1900,
                Title = "Volvo S40",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Hondas's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 245 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2100,
                Title = "Volvo S40",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Hondas's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 245 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2700,
                Title = "Mitsubishi Lancer",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Mitsubishi's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 255 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 1900,
                Title = "Mitsubishi Lancer",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Mitsubishi's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = false, Speed = 255 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 1900,
                Title = "Honda Civic",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Honda's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = false, Speed = 210 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2450,
                Title = "Honda Legend",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Honda's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 225 },
                IsRented = true,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };

            yield return new Sedan
            {
                Price = 2100,
                Title = "Honda Legend",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Honda's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 225 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = false }
            };

            yield return new Sedan
            {
                Price = 2850,
                Title = "Infiniti M III",
                Conditioner = new CarAirConditioner { IsWorkingWell = true, Title = "Infinity's Conditioner" },
                Engine = new CarEngine { IsWorkingWell = true, Speed = 225 },
                IsRented = false,
                Stereo = new CarStereo { Title = "Stock", IsWorkingWell = true }
            };
        }
    }
}
