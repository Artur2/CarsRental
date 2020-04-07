using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarsRental.Domain.Seedwork;

namespace CarsRental.Domain.Entities.Cars
{
    /// <summary>
    /// Main aggregate root related to renting car.
    /// </summary>
    public class Car : Entity
    {
        /// <summary>
        /// Title of car.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Flag of renting state.
        /// </summary>
        public bool IsRented { get; set; }

        /// <summary>
        /// Price of car for rent.
        /// </summary>
        [Required]
        public float Price { get; set; }

        /// <summary>
        /// Car related attributes.
        /// </summary>
        public virtual IList<CarAttribute> CarAttributes { get; set; }
    }
}
