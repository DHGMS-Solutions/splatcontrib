using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splat.Contrib.UnitTests
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using JetBrains.Annotations;

    using Splat;

    using Xunit;

    /// <summary>
    /// Unit tests for the Functional Full Logger class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class FunctionalFullLoggerTests
    {
        /// <summary>
        /// Unit tests for the constructor
        /// </summary>
        public sealed class ConstructorMethods
        {
            /// <summary>
            /// Unit test to check the class is created properly
            /// </summary>
            [Fact]
            public void ReturnsInstance()
            {
                var instance = new FunctionalFullLogger(LogHost.Default);
                Assert.NotNull(instance);
            }

            /// <summary>
            /// Unit test to ensure an argument null exception is thrown if no logger is passed.
            /// </summary>
            [Fact]
            public void ThrowsArgumentNullException()
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                Assert.Throws<ArgumentNullException>(() => new FunctionalFullLogger(null));
            }
        }

        /// <summary>
        /// Unit tests for the debug method
        /// </summary>
        public sealed class DebugMethod : BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>> MessageAction
            {
                get
                {
                    return (logger, stringFunc) => logger.Debug(stringFunc);
                }
            }
        }

        /// <summary>
        /// Unit tests for the debug exception method
        /// </summary>
        public sealed class DebugExceptionMethod : BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>, Exception> MessageAction
            {
                get
                {
                    return (logger, stringFunc, exception) => logger.DebugException(stringFunc, exception);
                }
            }
        }

        /// <summary>
        /// Unit tests for the error method
        /// </summary>
        public sealed class ErrorMethod : BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>> MessageAction
            {
                get
                {
                    return (logger, stringFunc) => logger.Error(stringFunc);
                }
            }
        }

        /// <summary>
        /// Unit tests for the error exception method
        /// </summary>
        public sealed class ErrorExceptionMethod : BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>, Exception> MessageAction
            {
                get
                {
                    return (logger, stringFunc, exception) => logger.ErrorException(stringFunc, exception);
                }
            }
        }

        /// <summary>
        /// Unit tests for the fatal method
        /// </summary>
        public sealed class FatalMethod : BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>> MessageAction
            {
                get
                {
                    return (logger, stringFunc) => logger.Fatal(stringFunc);
                }
            }
        }

        /// <summary>
        /// Unit tests for the fatal exception method
        /// </summary>
        public sealed class FatalExceptionMethod : BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>, Exception> MessageAction
            {
                get
                {
                    return (logger, stringFunc, exception) => logger.FatalException(stringFunc, exception);
                }
            }
        }

        /// <summary>
        /// Unit tests for the info method
        /// </summary>
        public sealed class InfoMethod : BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>> MessageAction
            {
                get
                {
                    return (logger, stringFunc) => logger.Info(stringFunc);
                }
            }
        }

        /// <summary>
        /// Unit tests for the info exception method
        /// </summary>
        public sealed class InfoExceptionMethod : BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>, Exception> MessageAction
            {
                get
                {
                    return (logger, stringFunc, exception) => logger.InfoException(stringFunc, exception);
                }
            }
        }

        /// <summary>
        /// Unit tests for the warn method
        /// </summary>
        public sealed class WarnMethod : BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>> MessageAction
            {
                get
                {
                    return (logger, stringFunc) => logger.Warn(stringFunc);
                }
            }
        }

        /// <summary>
        /// Unit tests for the warn exception method
        /// </summary>
        public sealed class WarnExceptionMethod : BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            protected override Action<FunctionalFullLogger, Func<String>, Exception> MessageAction
            {
                get
                {
                    return (logger, stringFunc, exception) => logger.WarnException(stringFunc, exception);
                }
            }
        }

        /// <summary>
        /// Base class for Log message method unit tests
        /// </summary>
        public abstract class BaseLogMessageMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message against.
            /// </summary>
            [NotNull]
            protected abstract Action<FunctionalFullLogger, Func<String>> MessageAction { get; }

            /// <summary>
            /// Unit test to log a message against the relevant message action.
            /// </summary>
            [Fact]
            public void LogsMessage()
            {
                var logger = new FunctionalFullLogger(LogHost.Default);
                this.MessageAction(logger, () => "message");
            }
        }

        /// <summary>
        /// Base class for Log Message with Exception method unit tests
        /// </summary>
        public abstract class BaseLogExceptionMethodTests
        {
            /// <summary>
            /// Gets the message action to log a message and exception against.
            /// </summary>
            [NotNull]
            protected abstract Action<FunctionalFullLogger, Func<String>, Exception> MessageAction { get; }

            /// <summary>
            /// Unit test to log a message and exception against the relevant message action.
            /// </summary>
            [Fact]
            public void LogsException()
            {
                var logger = new FunctionalFullLogger(LogHost.Default);
                this.MessageAction(logger, () => "message", new Exception());
            }
        }
    }
}
