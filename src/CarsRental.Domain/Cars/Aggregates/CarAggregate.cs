using CarsRental.Domain.Cars.Entities;
using CarsRental.Domain.Seedwork.Model;

namespace CarsRental.Domain.Cars.Aggregates
{
    /// <summary>
    /// Aggregate root of car.
    /// </summary>
    public class CarAggregate : IAggregateRoot
    {
        private readonly Car _car;

        public CarAggregate(Car car) => _car = car;

        /// <summary>
        /// Car Id.
        /// </summary>
        public int Id => _car.Id;

        /// <summary>
        /// Title of car.
        /// </summary>
        public string Title => _car.Title;

        /// <summary>
        /// Determine if car is tented.
        /// </summary>
        public bool IsRented => _car.IsRented;

        /// <summary>
        /// Price for rent.
        /// </summary>
        public float Price => _car.Price;

        /// <summary>
        /// Speed gaining by car's engine.
        /// </summary>
        public float Speed => _car.Engine.Speed;

        /// <summary>
        /// Checking if car has conditioner.
        /// </summary>
        public bool HasConditioner() => _car.Conditioner != null;

        /// <summary>
        /// Checking if car has stereo.
        /// </summary>
        public bool HasStereo() => _car.Stereo != null;

        /// <summary>
        /// Determine if air conditioner is working well.
        /// </summary>
        public bool IsAirConditionerWorkingWell() => _car.Conditioner.IsWorkingWell;

        /// <summary>
        /// Determine if stereo working well.
        /// </summary>
        public bool IsStereoWorkingWell() => _car.Stereo.IsWorkingWell;

        /// <summary>
        /// Determine if engine working well.
        /// </summary>
        public bool IsEngineWorkingWell() => _car.Engine.IsWorkingWell;
    }
}
