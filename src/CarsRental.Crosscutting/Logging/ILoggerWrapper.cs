using System;
using System.Runtime.CompilerServices;

namespace CarsRental.Crosscutting.Logging
{
    /// <summary>
    /// Wrapper for logging functionality.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface ILoggerWrapper<TContext>
    {
        /// <summary>
        /// Long term message for information gathering.
        /// </summary>
        void Information(string message, [CallerMemberName] string memberName = null, params object[] arguments);

        /// <summary>
        /// Short term message for information gathering. Usable only in debug.
        /// </summary>
        void Debug(string message, [CallerMemberName] string memberName = null, params object[] arguments);

        /// <summary>
        /// Short term message for information gathering with sensetive data. Usable only in debug.
        /// </summary>
        void Trace(string message, [CallerMemberName] string memberName = null, params object[] arguments);

        /// <summary>
        /// Long term message for warnings.
        /// Used for unexpected situation without app crash/etc.
        /// </summary>
        void Warning(string message, [CallerMemberName] string memberName = null, params object[] arguments);

        /// <summary>
        /// Long term message for errors.
        /// Used for unexpected situation without app crash/etc.
        /// </summary>
        void Error(string message, Exception exception, [CallerMemberName] string memberName = null, params object[] arguments);

        /// <summary>
        /// Long term message for critial/fatal errors.
        /// Used for unexpected situation with app crash/etc or when application can't rollback flow and stable state.
        /// </summary>
        void Critical(string message, Exception exception, [CallerMemberName] string memberName = null, params object[] arguments);
    }
}
