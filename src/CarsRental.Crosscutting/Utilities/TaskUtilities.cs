using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarsRental.Crosscutting.Utilities
{
    public static class TaskUtilities
    {
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
