using System.Collections.Generic;
using CarsRental.Domain.Seedwork;
using CarsRental.Domain.Seedwork.Model;

namespace CarsRental.Domain.Cars.Entities
{
    /// <summary>
    /// Car stereo with quality.
    /// </summary>
    public class CarStereo : ValueObject
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
