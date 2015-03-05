
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Tools.Modules.Provisionnement.Model.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IInternalData
    {
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IInternalDataColumn> Columns { get; }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IInternalDataRow this[int index] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        IEnumerable<IInternalDataRow> Select(string filter, string sort);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segement"></param>
        /// <returns></returns>
        IEnumerable<IInternalDataRow> Select(IDataSegment segement);
    }   
}

   
