namespace Splat
{
    using Splat;

    /// <summary>
    /// Interface that follows the same logic as IEnableLogger to allow splat to drop in logging methods onto a class an extension methods.
    /// </summary>
    public interface IEnableFunctionalLogger : IEnableLogger
    {
    }
}