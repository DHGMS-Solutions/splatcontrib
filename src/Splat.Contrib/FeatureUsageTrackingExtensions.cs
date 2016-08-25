using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splat
{
    public static class FeatureUsageTrackingExtensions
    {
        public static async Task SubFeatureAsync(
            this IFeatureUsageTrackingSession featureUsageTracking,
            string featureName,
            Task action)
        {
            using (var subFeature = featureUsageTracking.SubFeature(featureName))
            {
                try
                {
                    await action;
                }
                catch (Exception ex)
                {
                    subFeature.OnException(ex);

                    //re-throw so parent logic can deal with
                    throw;
                }
            }
        }

        public static async Task<TResult> SubFeatureAsync<TResult>(
            this IFeatureUsageTrackingSession featureUsageTracking,
            string featureName,
            Task<TResult> action)
        {
            using (var subFeature = featureUsageTracking.SubFeature(featureName))
            {
                try
                {
                    return await action;
                }
                catch (Exception ex)
                {
                    subFeature.OnException(ex);

                    //re-throw so parent logic can deal with
                    throw;
                }
            }
        }

        public static void SubFeature(
            this IFeatureUsageTrackingSession featureUsageTracking,
            string featureName,
            Action action)
        {
            using (var subFeature = featureUsageTracking.SubFeature(featureName))
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    subFeature.OnException(ex);

                    //re-throw so parent logic can deal with
                    throw;
                }
            }
        }

        public static TResult SubFeature<TResult>(
            this IFeatureUsageTrackingSession featureUsageTracking,
            string featureName,
            Func<TResult> func)
        {
            using (var subFeature = featureUsageTracking.SubFeature(featureName))
            {
                try
                {
                    return func();
                }
                catch (Exception ex)
                {
                    subFeature.OnException(ex);

                    //re-throw so parent logic can deal with
                    throw;
                }
            }
        }
    }
}
