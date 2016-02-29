using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Splat.Contrib.UnitTests
{
    public class TestableClass : IEnableFeatureUsageTracking
    {
        public TestableClass()
        {
            this.FeatureUsageTracking = Locator.Current.GetService<IFeatureUsageTrackingSession<Guid>>();
        }

        private IFeatureUsageTrackingSession<Guid> FeatureUsageTracking { get; }

        public void RandomSubFeature()
        {
            this.FeatureUsageTracking.SubFeature("RandomSubFeature", OnSubFeature);
        }

        public void RandomSubFeatureWithException()
        {
            this.FeatureUsageTracking.SubFeature("RandomSubFeature", OnSubFeatureWithException);
        }

        private void OnSubFeatureWithException()
        {
            throw new InvalidOperationException("OnSubFeatureWithException");
        }

        private void OnSubFeature()
        {
        }
    }

    public class FeatureUsageTrackingHostTests
    {
        public class FeatureUsageMethod
        {
            public void ReturnsInstance()
            {
                var instance = new TestableClass();
                Assert.NotNull(instance);
            }
        }
    }
}
