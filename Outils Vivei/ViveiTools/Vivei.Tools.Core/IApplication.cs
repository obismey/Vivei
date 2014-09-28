using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IService> GetServices();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPlugin> GetPlugins();

    }
}
