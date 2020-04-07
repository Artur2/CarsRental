using System.ComponentModel.DataAnnotations;

namespace CarsRental.Domain.Seedwork
{
    /// <summary>
    /// Base class for entity.
    /// </summary>
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
