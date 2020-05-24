using System;
using System.Collections.Generic;
using System.Linq;
using CarsRental.Domain.Seedwork.Data;
using Microsoft.Extensions.DependencyInjection;

namespace CarsRental.Infrastructure.Storage.Seed
{
    /// <summary>
    /// Implementation of <see cref="ISeedDataService"/>
    /// </summary>
    public class SeedDataService : ISeedDataService
    {
        private readonly IServiceProvider _serviceProvider;

        public SeedDataService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc cref="ISeedDataService.GetData{T}">
        public IEnumerable<T> GetData<T>() where T : class
        {
            var seedData = _serviceProvider.GetService<ISeedData<T>>();
            if (seedData == null)
            {
                // TODO: Logging
                return Enumerable.Empty<T>();
            }

            return seedData.GetData();
        }
    }
}
