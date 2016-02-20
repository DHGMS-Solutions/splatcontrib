namespace Splat
{
    using System;

    public interface IFeatureUsageTrackingSession
    {
        Guid FeatureReference { get; }

        string FeatureName { get; }

        IFeatureUsageTrackingSession SubFeature(string description);

        void OnException(Exception exception);
    }
}