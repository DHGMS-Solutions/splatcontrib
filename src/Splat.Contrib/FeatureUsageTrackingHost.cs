namespace Splat
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Extention methods for Feature Tracking Host
    /// </summary>
    [SuppressMessage("Usage", "Wintellect013:UseDebuggerDisplayAnalyzer", Justification = "Static Class with nothing useful")]
    public static class FeatureUsageTrackingHost
    {
        /// <summary>
        /// Call this method to write log entries on behalf of the current
        /// class.
        /// </summary>
        /// <typeparam name="TInstance">The type of the class implementing Functional Full Logger</typeparam>
        /// <param name="instance">The instance of a class that supports the functional log host via an extension method</param>
        /// <returns>The Functional Full Logger</returns>
        public static IFeatureUsageTrackingSession FeatureUsage<TInstance>(this TInstance instance)
            where TInstance : IFeatureUsageTrackingSession => null;
    }
}