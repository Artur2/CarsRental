using System.Collections.Generic;

namespace CarsRental.Domain.Seedwork
{
    public interface ISeedData<T> where T : class
    {
        public IEnumerable<T> GetData();
    }
}
