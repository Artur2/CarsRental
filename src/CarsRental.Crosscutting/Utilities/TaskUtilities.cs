using System;
using System.Threading.Tasks;

namespace CarsRental.Crosscutting.Utilities
{
    /// <summary>
    /// Extensions to <see cref="Task"/>.
    /// </summary>
    public static class TaskUtilities
    {
        /// <summary>
        /// Extension to just await Task.
        /// </summary>
        public static async void FireAndForgetSafeAsync(this Task task, Action<Exception> errorHandler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                errorHandler?.Invoke(ex);
            }
        }
    }
}
