using System;
using System.Collections.Generic;
using System.Linq;
using CarsRental.Domain.Seedwork.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarsRental.Infrastructure.Storage.Seed
{
    /// <summary>
    /// Implementation of <see cref="ISeedDataService"/>
    /// </summary>
    public class SeedDataService : ISeedDataService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public SeedDataService(IServiceProvider serviceProvider, ILogger<SeedDataService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        /// <inheritdoc cref="ISeedDataService.GetData{T}">
        public IEnumerable<T> GetData<T>() where T : class
        {
            var seedData = _serviceProvider.GetService<ISeedData<T>>();
            if (seedData == null)
            {
                _logger.LogError($"Not found seed data for {typeof(T).Name}");
                return Enumerable.Empty<T>();
            }

            return seedData.GetData();
        }
    }
}
