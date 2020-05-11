namespace CarsRental.Domain.Cars.Entities
{
    /// <summary>
    /// Type of car for sport.
    /// </summary>
    public class SportCar : Car
    {
        public override string CarType { get; protected set; } = Constants.CarTypeSport;
    }
}
