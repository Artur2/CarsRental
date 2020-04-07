using System.Collections.Generic;

namespace CarsRental.Domain.Aggregates
{
    /// <summary>
    /// Aggregate root of car.
    /// </summary>
    public class CarAggregate
    {
        /// <summary>
        /// Car Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of car.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Determine if car is tented.
        /// </summary>
        public bool IsRented { get; set; }

        /// <summary>
        /// Price for rent.
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// Attributes of car.
        /// </summary>
        public IReadOnlyCollection<CarAttribute> CarAttributes { get; set; }
    }
}
