using System.Collections.Generic;

namespace CarsRental.Domain.Seedwork
{
    /// <summary>
    /// Data service for seeding startup data.
    /// </summary>
    public interface ISeedDataService
    {
        /// <summary>
        /// Getting plain object for feed database.
        /// </summary>
        IEnumerable<T> GetData<T>() where T : class;
    }
}
