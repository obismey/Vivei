using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Molap.Core.Columns
{
	/// <summary>
	/// 
	/// </summary>
	public class ColumnCollection : IEnumerable<AbstractColumn>
	{
	    private List<AbstractColumn> cols;
	    private SortedList<string,AbstractColumn> colsdic;
	
	    /// <summary>
	    /// 
	    /// </summary>
	    public Table Table { get; private set; }
	
	    internal ColumnCollection(Core.Table result, List<AbstractColumn> cols)
	    {
	        this.Table = result;
	        this.cols = cols;
	        colsdic=new SortedList<string, AbstractColumn>();
	        foreach (var col in cols) {
	        	colsdic.Add(col.Name.ToLower(), col);
	        }
	    }
	
	    /// <summary>
	    /// 
	    /// </summary>
	    public int Count { get { return cols.Count; } }
	
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="index"></param>
	    /// <returns></returns>
	    public AbstractColumn GetColumn(int index)
	    {
	        return cols[index];
	    }
	    
	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="name"></param>
	    /// <returns></returns>
	    public AbstractColumn GetColumn(string name)
	    {
            return colsdic[name.ToLower()];
	    }
	
	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return cols.GetEnumerator();
	    }
	
	    IEnumerator<AbstractColumn> IEnumerable<AbstractColumn>.GetEnumerator()
	    {
	        return cols.GetEnumerator();
	    }
	}
}
