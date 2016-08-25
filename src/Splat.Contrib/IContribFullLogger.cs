using System.Collections.Generic;

namespace Splat
{
    public interface IContribFullLogger : IFullLogger
    {
        void SetContextProperties(IDictionary<string, string> contextPropertyCollection);
    }
}