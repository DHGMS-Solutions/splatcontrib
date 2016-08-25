using System;

namespace Splat
{
    public interface IContribLogManager
    {
        IContribFullLogger GetLogger(Type type);
    }
}