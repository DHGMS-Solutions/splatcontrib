namespace Splat
{
    using System;
    using System.Diagnostics;

    using JetBrains.Annotations;

    /// <summary>
    /// Wrapper for the Splat logger that only evaluates the string to be logged if the relevant log level is enabled
    /// </summary>
    [DebuggerDisplay("Level={_fullLogger.Level}")]
    public sealed class FunctionalFullLogger : IFunctionalFullLogger
    {
        private readonly IFullLogger _fullLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionalFullLogger"/> class.
        /// </summary>
        /// <param name="fullLogger">The splat full logger that will be used</param>
        /// <exception cref="ArgumentNullException">No splat logger was passed</exception>
        public FunctionalFullLogger([NotNull]IFullLogger fullLogger)
        {
            if (fullLogger == null)
            {
                throw new ArgumentNullException(nameof(fullLogger));
            }

            this._fullLogger = fullLogger;
        }

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public void Debug([NotNull]Func<String> valueFunction)
        {
            this.Act(LogLevel.Debug, valueFunction, this._fullLogger.Debug);
        }

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public void DebugException([NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            this.Act(LogLevel.Debug, valueFunction, this._fullLogger.Debug, exception);
        }

        /// <summary>
        /// Checks if the error log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public void Error([NotNull]Func<String> valueFunction)
        {
            this.Act(LogLevel.Error, valueFunction, this._fullLogger.Error);
        }

        /// <summary>
        /// Checks if the debug log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public void ErrorException([NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            this.Act(LogLevel.Error, valueFunction, this._fullLogger.Error, exception);
        }

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public void FatalException([NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            this.Act(LogLevel.Fatal, valueFunction, this._fullLogger.Fatal, exception);
        }

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public void Info([NotNull]Func<String> valueFunction)
        {
            this.Act(LogLevel.Info, valueFunction, this._fullLogger.Info);
        }

        /// <summary>
        /// Checks if the info log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public void InfoException([NotNull]Func<String> valueFunction, [NotNull]Exception exception)
        {
            this.Act(LogLevel.Info, valueFunction, this._fullLogger.Info, exception);
        }

        /// <summary>
        /// Checks if the fatal log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public void Fatal([NotNull]Func<String> valueFunction)
        {
            this.Act(LogLevel.Fatal, valueFunction, this._fullLogger.Fatal);
        }

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        public void Warn([NotNull]Func<String> valueFunction)
        {
            this.Act(LogLevel.Warn, valueFunction, this._fullLogger.Warn);
        }

        /// <summary>
        /// Checks if the warn log level is enabled then evaluates the string function and logs the message along with the exception.
        /// </summary>
        /// <param name="valueFunction">The string function to evaluate if the log level is enabled</param>
        /// <param name="exception">The exception that occurred</param>
        public void WarnException([NotNull]Func<String> valueFunction, Exception exception)
        {
            this.Act(LogLevel.Warn, valueFunction, this._fullLogger.Warn, exception);
        }

        private void Act(LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String> logAction)
        {
            if (this._fullLogger.Level <= thresholdLogLevel)
            {
                logAction.Invoke(valueFunction.Invoke());
            }
        }

        private void Act(LogLevel thresholdLogLevel, [NotNull]Func<String> valueFunction, [NotNull]Action<String, Exception> logAction, [NotNull]Exception ex)
        {
            if (this._fullLogger.Level <= thresholdLogLevel)
            {
                logAction.Invoke(valueFunction.Invoke(), ex);
            }
        }
    }
}
