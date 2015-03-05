using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Molap.Core.Columns
{
	internal class NumberColumn : AbstractColumn<double>
	{
	    internal NumberColumn(Table Table, int Index, string Name)
	        : base(Table, Index, Name)
	    {
	
	    }
	
	    protected internal override void InitializeValue(int rowindex, object value)
	    {
	        if (Convert.IsDBNull(value))
	        {
	            this.Data[rowindex] = double.NaN;
	        }
	        else
	        {
	            this.Data[rowindex] = Convert.ToDouble(value);
	        }
	    }
	
	    protected internal override object GetValue(int rowindex)
	    {
	        return this.Data[rowindex];
	    }
	
	    protected internal override string GetFormattedValue(int rowindex)
	    {
	        if (double.IsNaN(this.Data[rowindex])) return "(vide)";
	
	        return this.Data[rowindex].ToString(Format);
	    }
	
	}
}
