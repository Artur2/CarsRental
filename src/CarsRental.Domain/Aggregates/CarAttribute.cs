using CarsRental.Domain.Entities.Cars;

namespace CarsRental.Domain.Aggregates
{
    /// <summary>
    /// Attribute which belongs to <see cref="CarAggregate"/>.
    /// </summary>
    public class CarAttribute
    {
        /// <summary>
        /// Id of <see cref="CarAttribute"/>
        /// </summary>
        public int CarAttributeId { get; set; }

        /// <summary>
        /// Id of <see cref="CarAttributeType"/>
        /// </summary>
        public int CarAttributeTypeId { get; set; }

        /// <summary>
        /// Title of attribute.
        /// </summary>
        public string Title { get; set; }


        /// <summary>
        /// Value of attribute.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Quality of attribute.
        /// </summary>
        public CarAttributeQuality CarAttributeQuality { get; set; }
    }
}
