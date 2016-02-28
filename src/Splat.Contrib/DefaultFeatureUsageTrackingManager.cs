using System;

namespace Splat
{
    public class DefaultFeatureUsageTrackingManager : IFeatureUsageTrackingManager
    {
        public IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(Type type)
        {
            return new DefaultFeatureUsageTrackingSession(type.FullName);
        }
    }
}