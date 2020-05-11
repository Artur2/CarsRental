namespace CarsRental.Domain.Cars.Entities
{
    /// <summary>
    /// Vans car.
    /// </summary>
    public class Vans : Car
    {
        public override string CarType { get; protected set; } = Constants.CarTypeVans;
    }
}
