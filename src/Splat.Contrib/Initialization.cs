using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splat
{
    public static class Initialization
    {
        static Initialization()
        {
            Splat.Locator.CurrentMutable.Register(() => new DefaultFeatureUsageTrackingManager(), typeof(IFeatureUsageTrackingManager));
        }
    }
}
