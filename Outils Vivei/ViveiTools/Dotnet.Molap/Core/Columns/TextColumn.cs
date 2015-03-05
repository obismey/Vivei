using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet.Molap.Core.Columns
{
	internal class TextColumn : AbstractColumn<string>
	{
	
	    internal TextColumn(Table Table, int Index, string Name)
	        : base(Table, Index, Name)
	    {
	
	    }
	
	    protected internal override void InitializeValue(int rowindex, object value)
	    {
	        if (Convert.IsDBNull(value) || value == null)
	        {
	            this.Data[rowindex] = "";
	        }
	        else
	        {
	            this.Data[rowindex] = ((string)value).Trim();
	        }
	    }
	
	    protected internal override object GetValue(int rowindex)
	    {
	        return this.Data[rowindex];
	    }
	
	    protected internal override string GetFormattedValue(int rowindex)
	    {
	        if (string.IsNullOrEmpty(this.Data[rowindex])) return "(vide)";
	
	        return string.Format(string.IsNullOrEmpty(Format) ? "{0}" : Format, this.Data[rowindex]);
	    }
	}
}
