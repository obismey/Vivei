using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Molap.Core.Columns
{
	internal class DateColumn : AbstractColumn<System.DateTime>
	{
	    internal DateColumn(Table Table, int Index, string Name)
	        : base(Table, Index, Name)
	    {
	
	    }
		
	    protected internal override void InitializeValue(int rowindex, object value)
	    {
	        if (Convert.IsDBNull(value))
	        {
	            this.Data[rowindex] = DateTime.MinValue;
	        }
	        else
	        {
	            this.Data[rowindex] = (DateTime)value;
	        }
	    }
	
	    protected internal override object GetValue(int rowindex)
	    {
	        return this.Data[rowindex];
	    }
	
	    protected internal override string GetFormattedValue(int rowindex)
	    {
	        if (this.Data[rowindex] == DateTime.MinValue) return "(vide)";
	
	        return this.Data[rowindex].ToString(Format);
	    }
	}
}
