using System;
using JetBrains.Annotations;

namespace Splat
{
    public class DefaultFeatureUsageTrackingSession : IFeatureUsageTrackingSession<Guid>, IEnableFunctionalLogger
    {
        public DefaultFeatureUsageTrackingSession([NotNull] string featureName) : this(featureName, Guid.Empty)
        {
        }

        internal DefaultFeatureUsageTrackingSession([NotNull]string featureName, Guid parentReference)
        {
            if (string.IsNullOrWhiteSpace(featureName))
            {
                throw new ArgumentNullException(nameof(featureName));
            }

            this.ParentReference = parentReference;
            this.FeatureName = featureName;
            this.FeatureReference = Guid.NewGuid();
        }

        public Guid ParentReference { get; }

        public Guid FeatureReference { get; }

        public string FeatureName { get; }

        public IFeatureUsageTrackingSession SubFeature(string description)
        {
            return new DefaultFeatureUsageTrackingSession(description, this.FeatureReference);
        }

        public void OnException(Exception exception)
        {
            this.Log().InfoException(
                () => "Feature Usage Tracking Exception",
                exception);
        }
    }
}