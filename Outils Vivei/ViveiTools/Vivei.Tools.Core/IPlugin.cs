using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Core
{
    /// <summary>
    /// 
    /// </summary>
    [System.ComponentModel.Composition.InheritedExport()]
    public interface IPlugin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<IService> GetServices();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Application"></param>
        void Reset(IApplication Application);

    }
}
