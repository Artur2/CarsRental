using System.ComponentModel.DataAnnotations;
using CarsRental.Domain.Seedwork.Model;

namespace CarsRental.Domain.Cars.Entities
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

        // TODO: Need to change to value object
        /// <summary>
        /// Price of car for rent.
        /// </summary>
        [Required]
        public float Price { get; set; }

        [Required]
        public virtual string CarType { get; protected set; }

        /// <summary>
        /// Stereo inside of car.
        /// </summary>
        public CarStereo Stereo { get; set; }

        /// <summary>
        /// Conditioner inside of car.
        /// </summary>
        public CarAirConditioner Conditioner { get; set; }

        /// <summary>
        /// Engine of car.
        /// </summary>
        public CarEngine Engine { get; set; }
    }
}
