using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotnet.Molap.Core.Columns;
// linkdata du cote enfant
// data du cote parent 
// keydata pour les compteurs

namespace Dotnet.Molap.Core
{
    public class IndexTable
    {
        public ReadOnlyCollection<AbstractColumn> Columns
        {
            get
            {
                return new ReadOnlyCollection<AbstractColumn>(this._Columns);
            }
        }

        //public AbstractColumn LinkColumn { get; private set; }

        public int RowCount { get; private set; }

        public Table Table { get; private set; }

        private EqualityComparer _Comparer = null;

        private EqualityMultiComparer _MultiComparer = null;

        private Comparer _RowComparer = null;

        private AbstractColumn[] _Columns;

        internal int[] _Data = null;

        internal int[] _KeyData = null;

        internal int[] _LinkData = null;

        internal IndexTable(Core.Table table, AbstractColumn Column)
        {
            // TODO: Complete member initialization
            this._Comparer = new EqualityComparer();
            this._Comparer.Column = Column;
            this._RowComparer = new Comparer();
            this._RowComparer.Owner = this;

            this.Table = table;
            this._Columns = new AbstractColumn[] { Column };

            _LinkData = new int[table.RowCount];
            _Data = new int[this.Table.RowCount];

            Reset();
        }
        internal IndexTable(Core.Table table, params AbstractColumn[] Columns)
        {
            // TODO: Complete member initialization
            this._MultiComparer = new EqualityMultiComparer();
            this._MultiComparer.Columns = Columns;
            this._RowComparer = new Comparer();
            this._RowComparer.Owner = this;
            this.Table = table;
            this._Columns = Columns;

            _LinkData = new int[table.RowCount];
            _Data = new int[this.Table.RowCount];

            Reset();
        }

        internal int[] _ValueSortData = null;

        internal int[] _CountSortData = null;

        internal void Reset()
        {
            IEnumerable<IGrouping<int, int>> q = null;

            if (_Comparer != null)
            {
                q = Enumerable.Range(0, Table.RowCount).GroupBy(i => i, _Comparer);
            }
            else
            {
                q = Enumerable.Range(0, Table.RowCount).GroupBy(i => i, _MultiComparer);
            }

            var counter = 0;
            var gcounter = 0;

            _KeyData = new int[this.Table.RowCount];

            foreach (var g in q)
            {
                this._KeyData[gcounter] = counter;

                foreach (var i in g)
                {
                    this._LinkData[i] = gcounter;

                    this._Data[counter] = i;

                    counter += 1;
                }

                gcounter += 1;
            }

            RowCount = gcounter;

            Array.Resize<int>(ref this._KeyData, gcounter);

            GetSortedByCount(0);

            GetSortedByValue(0);

        }

        public object GetValue(int index)
        {
            return Columns[0].GetValue(_Data[_KeyData[index]]);
        }

        public object GetValue(int index, int colindex)
        {
            return Columns[colindex].GetValue(_Data[_KeyData[index]]);
        }
        
        public object GetValue(int index, AbstractColumn column)
        {
            return column.GetValue(_Data[_KeyData[index]]);
        }
        
        public string GetFormattedValue(int index)
        {
            return Columns[0].GetFormattedValue(_Data[_KeyData[index]]);
        }

        public string GetFormattedValue(int index, int colindex)
        {
            return Columns[colindex].GetFormattedValue(_Data[_KeyData[index]]);
        }
        
        public string GetFormattedValue(int index, AbstractColumn  column)
        {
            return column.GetFormattedValue(_Data[_KeyData[index]]);
        }

        public int GetCount(int index)
        {
            if (index == RowCount - 1) return Table.RowCount - _KeyData[index];

            return _KeyData[index + 1] - _KeyData[index];
        }

        public int GetTableIndex(int index, int posindex)
        {
            return _Data[_KeyData[index] + posindex];
        }

        public int GetKey(int index)
        {
            return _LinkData[index];
        }

        public int GetValueKey(object value)
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                if (object.Equals(value, Columns[0].GetValue(_Data[_KeyData[i]])))
                {
                    return i;
                }
            }
            return -1;
        }

        public int GetSortedByValue(int index)
        {
            if (_ValueSortData == null)
            {
                if (Columns.Count == 1)
                {
                    _ValueSortData = Enumerable.Range(0, RowCount).ToArray().OrderBy(i => GetValue(i)).ToArray();
                }
                else
                {
                    _ValueSortData = Enumerable.Range(0, RowCount).ToArray().OrderBy(i => i, _RowComparer).ToArray();
                }
            }

            return _ValueSortData[index];
        }
        
        public int GetSortedByCount(int index)
        {
            if (_CountSortData == null)
            {
                _CountSortData = Enumerable.Range(0, RowCount).ToArray().OrderBy(i => GetCount(i)).ToArray();
            }
            return _CountSortData[index];
        }

        private class EqualityComparer : IEqualityComparer<int>
        {
            public AbstractColumn Column;

            public bool Equals(int x, int y)
            {
                return object.Equals(Column.GetValue(x), Column.GetValue(y));
            }

            public int GetHashCode(int obj)
            {
                return Column.GetValue(obj).GetHashCode();
            }
        }

        private class EqualityMultiComparer : IEqualityComparer<int>
        {
            public AbstractColumn[] Columns;

            public bool Equals(int x, int y)
            {
                for (int i = 0; i < Columns.Length; i++)
                {
                    if (!object.Equals(Columns[i].GetValue(x), Columns[i].GetValue(y)))
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(int obj)
            {
                var result = CombineHashCodes(
                                Columns[0].GetValue(obj).GetHashCode(),
                                Columns[1].GetValue(obj).GetHashCode());

                for (int i = 2; i < Columns.Length; i++)
                {
                    result = CombineHashCodes(
                                result,
                                Columns[i].GetValue(obj).GetHashCode());
                }

                return result;
            }

            private static int CombineHashCodes(int h1, int h2)
            {
                return (h1 << 5) + h1 ^ h2;
            }
        }

        private class Comparer : IComparer<int>
        {
            public IndexTable Owner;

            public int Compare(int x, int y)
            {
                for (int i = 0; i < Owner._Columns.Length; i++)
                {
                    if (!object.Equals(Owner.GetValue(x, i), Owner.GetValue(y, i)))
                    {
                        return System.Collections.Comparer.Default.Compare(
                                    Owner.GetValue(x, i),
                                    Owner.GetValue(y, i));
                    }
                }

                return 0;
            }
        }

        //internal class Link
        //{
        //    public Core.IndexTable Parent { get; private set; }

        //    public Core.IndexTable Child { get; private set; }

        //    //private int[] _Data = null;

        //    //private int[] _KeyData = null;

        //    internal int[] _LinkData = null;

        //    public Link(Core.IndexTable parent, Core.IndexTable child)
        //    {
        //        this.Parent = parent;
        //        this.Child = child;

        //        _LinkData = new int[child.RowCount];
        //        //_Data = new int[child.RowCount];
        //        //_KeyData = new int[parent.RowCount];
        //        Reset();
        //    }

        //    private void Reset()
        //    {
        //        for (int i = 0; i < Child.RowCount; i++)
        //        {
        //            _LinkData[i] = Parent._LinkData[Child._Data[Child._KeyData[i]]];
        //        }
        //    }


        //}
    }
}
