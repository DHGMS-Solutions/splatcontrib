using System.Collections.ObjectModel;

namespace Splat
{
    public interface IContribFullLogger : IFullLogger
    {
        void SetContextProperties(KeyedCollection<string, string> contextPropertyCollection);
    }
}