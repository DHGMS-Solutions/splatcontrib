using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Splat
{
    public class DefaultContribLogManager : ILogManager
    {
        readonly MemoizingMRUCache<Type, IContribFullLogger> loggerCache;

        public DefaultContribLogManager(IDependencyResolver dependencyResolver = null)
        {
            dependencyResolver = dependencyResolver ?? Locator.Current;

            loggerCache = new MemoizingMRUCache<Type, IContribFullLogger>((type, _) =>
            {
                var ret = dependencyResolver.GetService<IContribLogger>();
                if (ret == null)
                {
                    throw new Exception(
                        "Couldn't find an IContribLogger. This should never happen, your dependency resolver is probably broken.");
                }

                return new WrappingContribFullLogger(ret, type);
            }, 64);
        }

        static readonly IContribFullLogger nullLogger = new WrappingContribFullLogger(new NullContribLogger(),
            typeof (MemoizingMRUCache<Type, IContribFullLogger>));

        public IFullLogger GetLogger(Type type)
        {
            if (type == typeof (MemoizingMRUCache<Type, IContribFullLogger>)) return nullLogger;

            lock (loggerCache)
            {
                return loggerCache.Get(type);
            }
        }
    }

    #region Extremely Dull Code Ahead
    public class WrappingContribFullLogger : IContribFullLogger
    {
        readonly IContribLogger _inner;
        readonly string prefix;
        readonly MethodInfo stringFormat;

        public WrappingContribFullLogger(IContribLogger inner, Type callingType)
        {
            _inner = inner;
            prefix = String.Format(CultureInfo.InvariantCulture, "{0}: ", callingType.Name);

            stringFormat = typeof(String).GetMethod("Format", new[] { typeof(IFormatProvider), typeof(string), typeof(object[]) });
            Contract.Requires(inner != null);
            Contract.Requires(stringFormat != null);
        }

        string InvokeStringFormat(IFormatProvider formatProvider, string message, object[] args)
        {
            var sfArgs = new object[3];
            sfArgs[0] = formatProvider;
            sfArgs[1] = message;
            sfArgs[2] = args;
            return (string)stringFormat.Invoke(null, sfArgs);
        }

        public void Debug<T>(T value)
        {
            _inner.Write(prefix + value, LogLevel.Debug);
        }

        public void Debug<T>(IFormatProvider formatProvider, T value)
        {
            _inner.Write(String.Format(formatProvider, "{0}{1}", prefix, value), LogLevel.Debug);
        }

        public void DebugException(string message, Exception exception)
        {
            _inner.Write(String.Format("{0}{1}: {2}", prefix, message, exception), LogLevel.Debug);
        }

        public void Debug(IFormatProvider formatProvider, string message, params object[] args)
        {
            var result = InvokeStringFormat(formatProvider, message, args);

            _inner.Write(prefix + result, LogLevel.Debug);
        }


        public void Debug(string message)
        {
            _inner.Write(prefix + message, LogLevel.Debug);
        }

        public void Debug(string message, params object[] args)
        {
            var result = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
            _inner.Write(prefix + result, LogLevel.Debug);
        }

        public void Debug<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument), LogLevel.Debug);
        }

        public void Debug<TArgument>(string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument), LogLevel.Debug);
        }

        public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2), LogLevel.Debug);
        }

        public void Debug<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2), LogLevel.Debug);
        }

        public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Debug);
        }

        public void Debug<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2, argument3), LogLevel.Debug);
        }

        public void Info<T>(T value)
        {
            _inner.Write(prefix + value, LogLevel.Info);
        }

        public void Info<T>(IFormatProvider formatProvider, T value)
        {
            _inner.Write(String.Format(formatProvider, "{0}{1}", prefix, value), LogLevel.Info);
        }

        public void InfoException(string message, Exception exception)
        {
            _inner.Write(String.Format("{0}{1}: {2}", prefix, message, exception), LogLevel.Info);
        }

        public void Info(IFormatProvider formatProvider, string message, params object[] args)
        {
            var result = InvokeStringFormat(formatProvider, message, args);
            _inner.Write(prefix + result, LogLevel.Info);
        }

        public void Info(string message)
        {
            _inner.Write(prefix + message, LogLevel.Info);
        }

        public void Info(string message, params object[] args)
        {
            var result = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
            _inner.Write(prefix + result, LogLevel.Info);
        }

        public void Info<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument), LogLevel.Info);
        }

        public void Info<TArgument>(string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument), LogLevel.Info);
        }

        public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2), LogLevel.Info);
        }

        public void Info<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2), LogLevel.Info);
        }

        public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Info);
        }

        public void Info<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2, argument3), LogLevel.Info);
        }

        public void Warn<T>(T value)
        {
            _inner.Write(prefix + value, LogLevel.Warn);
        }

        public void Warn<T>(IFormatProvider formatProvider, T value)
        {
            _inner.Write(String.Format(formatProvider, "{0}{1}", prefix, value), LogLevel.Warn);
        }

        public void WarnException(string message, Exception exception)
        {
            _inner.Write(String.Format("{0}{1}: {2}", prefix, message, exception), LogLevel.Warn);
        }

        public void Warn(IFormatProvider formatProvider, string message, params object[] args)
        {
            var result = InvokeStringFormat(formatProvider, message, args);
            _inner.Write(prefix + result, LogLevel.Warn);
        }

        public void Warn(string message)
        {
            _inner.Write(prefix + message, LogLevel.Warn);
        }

        public void Warn(string message, params object[] args)
        {
            var result = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
            _inner.Write(prefix + result, LogLevel.Warn);
        }

        public void Warn<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument), LogLevel.Warn);
        }

        public void Warn<TArgument>(string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument), LogLevel.Warn);
        }

        public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2), LogLevel.Warn);
        }

        public void Warn<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2), LogLevel.Warn);
        }

        public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Warn);
        }

        public void Warn<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2, argument3), LogLevel.Warn);
        }


        public void Error<T>(T value)
        {
            _inner.Write(prefix + value, LogLevel.Error);
        }

        public void Error<T>(IFormatProvider formatProvider, T value)
        {
            _inner.Write(String.Format(formatProvider, "{0}{1}", prefix, value), LogLevel.Error);
        }

        public void ErrorException(string message, Exception exception)
        {
            _inner.Write(String.Format("{0}{1}: {2}", prefix, message, exception), LogLevel.Error);
        }

        public void Error(IFormatProvider formatProvider, string message, params object[] args)
        {
            var result = InvokeStringFormat(formatProvider, message, args);
            _inner.Write(prefix + result, LogLevel.Error);
        }

        public void Error(string message)
        {
            _inner.Write(prefix + message, LogLevel.Error);
        }

        public void Error(string message, params object[] args)
        {
            var result = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
            _inner.Write(prefix + result, LogLevel.Error);
        }

        public void Error<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument), LogLevel.Error);
        }

        public void Error<TArgument>(string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument), LogLevel.Error);
        }

        public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2), LogLevel.Error);
        }

        public void Error<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2), LogLevel.Error);
        }

        public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Error);
        }

        public void Error<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2, argument3), LogLevel.Error);
        }


        public void Fatal<T>(T value)
        {
            _inner.Write(prefix + value, LogLevel.Fatal);
        }

        public void Fatal<T>(IFormatProvider formatProvider, T value)
        {
            _inner.Write(String.Format(formatProvider, "{0}{1}", prefix, value), LogLevel.Fatal);
        }

        public void FatalException(string message, Exception exception)
        {
            _inner.Write(String.Format("{0}{1}: {2}", prefix, message, exception), LogLevel.Fatal);
        }

        public void Fatal(IFormatProvider formatProvider, string message, params object[] args)
        {
            var result = InvokeStringFormat(formatProvider, message, args);
            _inner.Write(prefix + result, LogLevel.Fatal);
        }

        public void Fatal(string message)
        {
            _inner.Write(prefix + message, LogLevel.Fatal);
        }

        public void Fatal(string message, params object[] args)
        {
            var result = InvokeStringFormat(CultureInfo.InvariantCulture, message, args);
            _inner.Write(prefix + result, LogLevel.Fatal);
        }

        public void Fatal<TArgument>(IFormatProvider formatProvider, string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument), LogLevel.Fatal);
        }

        public void Fatal<TArgument>(string message, TArgument argument)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument), LogLevel.Fatal);
        }

        public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2), LogLevel.Fatal);
        }

        public void Fatal<TArgument1, TArgument2>(string message, TArgument1 argument1, TArgument2 argument2)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2), LogLevel.Fatal);
        }

        public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(formatProvider, message, argument1, argument2, argument3), LogLevel.Fatal);
        }

        public void Fatal<TArgument1, TArgument2, TArgument3>(string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
        {
            _inner.Write(prefix + String.Format(CultureInfo.InvariantCulture, message, argument1, argument2, argument3), LogLevel.Fatal);
        }

        public void SetContextProperties(IDictionary<string, string> contextPropertyCollection)
        {
            _inner.SetContextProperties(contextPropertyCollection);
        }

        public void Write([Localizable(false)] string message, LogLevel logLevel)
        {
            _inner.Write(message, logLevel);
        }

        public LogLevel Level
        {
            get { return _inner.Level; }
            set { _inner.Level = value; }
        }
    }

    public interface IContribLogger : ILogger
    {
        void SetContextProperties(IDictionary<string, string> contextPropertyCollection);
    }

    #endregion
}
