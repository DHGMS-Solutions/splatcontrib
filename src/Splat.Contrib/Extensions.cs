namespace Splat
{
    using System;
    using System.Collections.ObjectModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    public static class FullLoggerExtensions
    {
            /// <summary>
        /// Checks if the Debug log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Debug(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug);
        }

        /// <summary>
        /// Checks if the Debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void DebugException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug, exception);
        }

        /// <summary>
        /// Checks if the Error log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Error(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error);
        }

        /// <summary>
        /// Checks if the Error log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void ErrorException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error, exception);
        }

        /// <summary>
        /// Checks if the Fatal log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Fatal(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal);
        }

        /// <summary>
        /// Checks if the Fatal log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void FatalException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal, exception);
        }

        /// <summary>
        /// Checks if the Info log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Info(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info);
        }

        /// <summary>
        /// Checks if the Info log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void InfoException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info, exception);
        }

        /// <summary>
        /// Checks if the Warn log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public static void Warn(this IFullLogger logger, [NotNull]Func<String> valueFunction)
        {
            Act(logger, LogLevel.Warn, valueFunction, logger.Warn);
        }

        /// <summary>
        /// Checks if the Warn log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public static void WarnException(this IFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception)
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

    public static class ContribFullLoggerExtensions
    {
            /// <summary>
        /// Checks if the Debug log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void Debug(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void DebugException(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Debug, valueFunction, logger.Debug, exception, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Error log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void Error(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Error log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void ErrorException(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Error, valueFunction, logger.Error, exception, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Fatal log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void Fatal(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Fatal log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void FatalException(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Fatal, valueFunction, logger.Fatal, exception, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Info log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void Info(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Info log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void InfoException(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Info, valueFunction, logger.Info, exception, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Warn log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void Warn(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Warn, valueFunction, logger.Warn, contextPropertyCollection);
        }

        /// <summary>
        /// Checks if the Warn log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="logger">The splat logger.</param>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        /// <param name="contextPropertyCollection">Collection of Key\Value pairs to attach as properties to the logging context</param>
        public static void WarnException(this IContribFullLogger logger, [NotNull]Func<String> valueFunction, [NotNull]Exception exception, KeyedCollection<string, string> contextPropertyCollection)
        {
            Act(logger, LogLevel.Warn, valueFunction, logger.Warn, exception, contextPropertyCollection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Act(IContribFullLogger logger, LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String> logAction, KeyedCollection<string, string> contextPropertyCollection)
        {
            if (logger.Level <= thresholdLogLevel)
            {
                if (contextPropertyCollection != null && contextPropertyCollection.Count > 0)
                {
                    logger.SetContextProperties(contextPropertyCollection);
                }

                logAction.Invoke(valueFunction.Invoke());
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Act(IContribFullLogger logger, LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String, Exception> logAction, [NotNull]Exception ex, KeyedCollection<string, string> contextPropertyCollection)
        {
            if (logger.Level <= thresholdLogLevel)
            {
                if (contextPropertyCollection != null && contextPropertyCollection.Count > 0)
                {
                    logger.SetContextProperties(contextPropertyCollection);
                }

                logAction.Invoke(valueFunction.Invoke(), ex);
            }
        }
    }
}