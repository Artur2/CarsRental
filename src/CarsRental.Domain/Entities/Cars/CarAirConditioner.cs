﻿using CarsRental.Domain.Seedwork;
using System.Collections.Generic;

namespace CarsRental.Domain.Entities.Cars
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
