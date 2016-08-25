using System;
using JetBrains.Annotations;

namespace Splat
{
    public class DefaultFeatureUsageTrackingSession : IFeatureUsageTrackingSession<Guid>, IEnableContribLogger
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

            var message = $"Feature Start. Reference={this.FeatureReference}";
            if (this.ParentReference != Guid.Empty)
            {
                message += $", Parent Reference={this.ParentReference}";
            }

            // vs getting confused over IEnable... interfaces and extension methods
            ContribLogHostExtensions.Log(this).Info(() => message);
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
            // vs getting confused over IEnable... interfaces and extension methods
            ContribLogHostExtensions.Log(this).InfoException(
                () => "Feature Usage Tracking Exception",
                exception);
        }

        public void Dispose()
        {
            // vs getting confused over IEnable... interfaces and extension methods
            ContribLogHostExtensions.Log(this).Info(() => $"Feature Finish: {this.FeatureReference}");
        }
    }
}