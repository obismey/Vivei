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
    public abstract class AbstractColumn
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual int Index { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Table Table { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="value"></param>
        protected internal abstract void InitializeValue(int rowindex, object value);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        protected internal abstract object GetValue(int rowindex);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        protected internal virtual string GetFormattedValue(int rowindex)
        {
            return GetValue(rowindex).ToString();
        }

        internal AbstractColumn()
        {
            this.Format = "";
        }

        internal AbstractColumn(Table Table, int Index, string Name)
        {
            this.Table = Table;
            this.Index = Index;
            this.Name = Name;
            this.Format = "";
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual Type Type { get { return null ; } }

    }

    internal abstract class AbstractColumn<T> : AbstractColumn
    {

        internal T[] Data = null;

        public override Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        protected internal override void InitializeValue(int rowindex, object value)
        {

        }

        protected internal override object GetValue(int rowindex)
        {
            throw new NotImplementedException();
        }

        internal AbstractColumn()
            : base()
        {

        }

        internal AbstractColumn(Table Table, int Index, string Name)
            : base(Table, Index, Name)
        {

        }
    }

}
