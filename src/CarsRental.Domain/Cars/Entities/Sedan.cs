namespace CarsRental.Domain.Cars.Entities
{
    /// <summary>
    /// Sedan type of car.
    /// </summary>
    public class Sedan : Car
    {
        public override string CarType { get; protected set; } = Constants.CarTypeSedan;
    }
}
