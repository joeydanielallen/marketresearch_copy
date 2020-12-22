using System;

namespace afmr.model
{
    /// <summary>
    /// Logging interface used by Domain. Implementation expected by host.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Log an error meddage
        /// </summary>
        /// <param name="errorMessage"></param>
        void LogError(string errorMessage);

        /// <summary>
        /// Log an error with exception
        /// </summary>
        /// <param name="exception"></param>
        void LogError(Exception exception);

        /// <summary>
        /// Log an error message and exception;
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="errorMessage"></param>
        void LogError(Exception exception, string errorMessage);

        /// <summary>
        /// Log information
        /// </summary>
        /// <param name="message"></param>
        void LogInformation(string message);

        /// <summary>
        /// Log debug information
        /// </summary>
        /// <param name="message"></param>
        void LogDebug(string message);
    }
}
