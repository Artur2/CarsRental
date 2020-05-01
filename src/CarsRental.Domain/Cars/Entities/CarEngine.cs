using System.Collections.Generic;
using CarsRental.Domain.Seedwork.Model;

namespace CarsRental.Domain.Cars.Entities
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
