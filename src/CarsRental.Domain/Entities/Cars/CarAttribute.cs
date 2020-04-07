using CarsRental.Domain.Seedwork;

namespace CarsRental.Domain.Entities.Cars
{
    /// <summary>
    /// Attribute of car.
    /// </summary>
    public class CarAttribute : Entity
    {
        /// <summary>
        /// Car's Id.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Car instance.
        /// </summary>
        public virtual Car Car { get; set; }

        /// <summary>
        /// Id of car attribute type.
        /// </summary>
        public int CarAttributeTypeId { get; set; }

        /// <summary>
        /// Car attribute type.
        /// </summary>
        public virtual CarAttributeType CarAttributeType { get; set; }

        /// <summary>
        /// Quality of Car's attribute.
        /// </summary>
        public CarAttributeQuality CarAttributeQuality { get; set; }
    }
}
