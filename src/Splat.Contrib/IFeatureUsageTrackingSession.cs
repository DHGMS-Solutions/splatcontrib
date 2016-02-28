namespace Splat
{
    using System;

    public interface IFeatureUsageTrackingSession<out TReferenceType> : IFeatureUsageTrackingSession
    {
        TReferenceType FeatureReference { get; }

        TReferenceType ParentReference { get; }

        string FeatureName { get; }
    }

    public interface IFeatureUsageTrackingSession
    {
        IFeatureUsageTrackingSession SubFeature(string description);

        void OnException(Exception exception);
    }
}