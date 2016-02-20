namespace Splat
{
    using System;

    /// <summary>
    /// Interface for Full Functional Logger. Follows the concept from Splat for a Full Logger.
    /// </summary>
    public interface IFunctionalFullLogger
    {
        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        void Debug(Func<String> valueFunction);

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        void DebugException(Func<String> valueFunction, Exception exception);

        /// <summary>
        /// Checks if the error log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        void Error(Func<String> valueFunction);

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        void ErrorException(Func<String> valueFunction, Exception exception);

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        void Fatal(Func<String> valueFunction);

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        void FatalException(Func<String> valueFunction, Exception exception);

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        void Info(Func<String> valueFunction);

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        void InfoException(Func<String> valueFunction, Exception exception);

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        void Warn(Func<String> valueFunction);

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        void WarnException(Func<String> valueFunction, Exception exception);
    }
}