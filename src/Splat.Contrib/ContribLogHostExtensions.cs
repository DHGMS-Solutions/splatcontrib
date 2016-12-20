using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splat
{
    public static class ContribLogHostExtensions
    {
        /// <summary>
        /// Use this logger inside miscellaneous static methods where creating
        /// a class-specific logger isn't really worth it.
        /// </summary>
        public static IContribFullLogger Default
        {
            get
            {
                var factory = Locator.Current.GetService<IContribLogManager>();
                if (factory == null)
                {
                    throw new Exception("IContribLogManager is null. This should never happen, your dependency resolver is broken");
                }
                return factory.GetLogger(typeof(ContribLogHost));
            }
        }

        /// <summary>
        /// Call this method to write log entries on behalf of the current 
        /// class.
        /// </summary>
        public static IContribFullLogger ContribLog<T>(this T This) where T : IEnableContribLogger
        {
            var factory = Locator.Current.GetService<IContribLogManager>();
            if (factory == null)
            {
                throw new Exception("IContribLogManager is null. This should never happen, your dependency resolver is broken");
            }

            return factory.GetLogger<T>();
        }
    }
    public static class LogManagerMixin
    {
        public static IContribFullLogger GetLogger<T>(this IContribLogManager This)
        {
            return This.GetLogger(typeof(T));
        }
    }
}
