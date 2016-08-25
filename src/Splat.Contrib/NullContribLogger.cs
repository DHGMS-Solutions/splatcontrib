using System.Collections.Generic;

namespace Splat
{
    public class NullContribLogger : NullLogger, IContribLogger
    {
        public void SetContextProperties(IDictionary<string, string> contextPropertyCollection)
        {
        }
    }
}