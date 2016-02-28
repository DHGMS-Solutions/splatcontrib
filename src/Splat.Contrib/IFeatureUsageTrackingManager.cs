using System;

namespace Splat
{
    public interface IFeatureUsageTrackingManager
    {
        IFeatureUsageTrackingSession GetFeatureUsageTrackingSession(Type type);
    }
}