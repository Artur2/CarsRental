using System;
using System.Collections.Generic;
using System.Text;
using CarsRental.Domain.Seedwork;

namespace CarsRental.Domain.Entities.Cars
{
    /// <summary>
    /// Attribute of car for rent.
    /// </summary>
    public class CarAttributeType : Entity
    {
        /// <summary>
        /// Title of car's attribute.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Value of attribute.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Attributes list.
        /// </summary>
        public IList<CarAttribute> CarAttributes { get; set; }
    }
}
