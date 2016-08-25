using System;

namespace Splat
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Extention methods for Feature Tracking Host
    /// </summary>
    [SuppressMessage("Usage", "Wintellect013:UseDebuggerDisplayAnalyzer", Justification = "Static Class with nothing useful")]
    public static class FeatureUsageTrackingHostExtensions
    {
        /// <summary>
        /// Gets a Feature Usage tracking session for the class.
        /// </summary>
        /// <typeparam name="TInstance">The type of the class implementing a Feature Usage Tracking Session</typeparam>
        /// <param name="instance">The instance of a class that supports a Feature Usage Tracking Session via an extension method</param>
        /// <returns>The Feature Usage Tracking Session</returns>
        public static IFeatureUsageTrackingSession FeatureUsage<TInstance>(this TInstance instance)
            where TInstance : IFeatureUsageTrackingSession
        {
            var service = Locator.Current.GetService<IFeatureUsageTrackingManager>();
            if (service == null)
            {
                throw new Exception("Couldn't find an ILogger. This should never happen, your dependency resolver is probably broken.");
            }

            return service.GetFeatureUsageTrackingSession(typeof (TInstance));
        }
    }
}