using System.Collections.Generic;
using CarsRental.Domain.Seedwork.Model;

namespace CarsRental.Domain.Cars.Entities
{
    /// <summary>
    /// Car's conditioner with quality.
    /// </summary>
    public class CarAirConditioner : ValueObject
    {
        public string Title { get; set; }

        public bool IsWorkingWell { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Title;
            yield return IsWorkingWell;
        }
    }
}
