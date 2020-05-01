using System.Collections.Generic;

namespace CarsRental.Domain.Seedwork.Data
{
    public interface ISeedData<T> where T : class
    {
        public IEnumerable<T> GetData();
    }
}
