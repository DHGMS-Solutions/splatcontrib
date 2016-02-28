using System.Runtime.CompilerServices;

namespace Splat
{
    using System;
    using System.Diagnostics;

    using JetBrains.Annotations;

    /// <summary>
    /// Wrapper for the Splat logger that only evaluates the string to be logged if the relevant log level is enabled
    /// </summary>
    public static class FunctionalFullLogger
    {
        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Debug(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug);
        }

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void DebugException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug, exception);
        }

        /// <summary>
        /// Checks if the error log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Error(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error);
        }

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void ErrorException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error, exception);
        }

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void FatalException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal, exception);
        }

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Info(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info);
        }

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void InfoException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info, exception);
        }

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Fatal(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal);
        }

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Warn(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Warn, valueFunction, logger.Warn);
        }

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void WarnException(this IFullLogger logger, [NotNull]Func<String> valueFunction, Exception exception)
        {
            Act(logger, LogLevel.Warn, valueFunction, logger.Warn, exception);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Act(IFullLogger logger, LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String> logAction)
        {
            if (logger.Level <= thresholdLogLevel)
            {
                logAction.Invoke(valueFunction.Invoke());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Act(IFullLogger logger, LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String, Exception> logAction, [NotNull]Exception ex)
        {
            if (logger.Level <= thresholdLogLevel)
            {
                logAction.Invoke(valueFunction.Invoke(), ex);
            }
        }
    }
}
