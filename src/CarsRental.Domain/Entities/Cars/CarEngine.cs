using CarsRental.Domain.Seedwork;
using System.Collections.Generic;

namespace CarsRental.Domain.Entities.Cars
{
    /// <summary>
    /// Represents car engine.
    /// </summary>
    public class CarEngine : ValueObject
    {
        /// <summary>
        /// Speed of Car's engine.
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Flag for determine if engine workging well.
        /// </summary>
        public bool IsWorkingWell { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Speed;
            yield return IsWorkingWell;
        }
    }
}
