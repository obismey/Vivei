using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Vivei.Tools.Modules.Provisionnement.Model.Interfaces;

namespace Vivei.Tools.Plugins.Reserving.Core
{
    public class DefaultTriangleData : ITriangleData
    {
        private int _DiagonalRow;
        private int _DiagonalColumn;
        private TriangleFormat _Format;
        private ITriangleDataProvider _Provider;
        private int _ColumnCount;
        private int _RowCount;
        private double?[] _Data;
        private string[] _RowLabels;
        private string[] _ColumnLabels;

        public DefaultTriangleData(
             int RowCount,
             int ColumnCount,
             int DiagonalColumn,
             int DiagonalRow,
             TriangleFormat Format,
             ITriangleDataProvider Provider,
             string[] RowLabels,
             string[] ColumnLabels,
             double?[] Data)
        {
            this._RowCount = RowCount;
            this._ColumnCount = ColumnCount;
            this._DiagonalRow = DiagonalRow;
            this._DiagonalColumn = DiagonalColumn;
            this._Format = Format;
            this._Provider = Provider;

            this._Data = Data;
            this._RowLabels = RowLabels;
            this._ColumnLabels = ColumnLabels;
        }

        public string GetRowLabel(int index)
        {
            return _RowLabels[index];
        }

        public string GetColumnLabel(int index)
        {
            return _ColumnLabels[index];
        }

        public int RowCount
        {
            get { return _RowCount; }
        }

        public int ColumnCount
        {
            get { return _ColumnCount; }
        }

        public int DiagonalColumn
        {
            get { return _DiagonalColumn; }
        }

        public int DiagonalRow
        {
            get { return _DiagonalRow; }
        }

        public double? GetValue(int rowindex, int columnindex)
        {
            return this._Data[rowindex * this._ColumnCount + columnindex];
        }

        public Modules.Provisionnement.Model.Property GetProperty(string name, int rowindex, int columnindex)
        {
            return null;
        }

        public TriangleFormat Format
        {
            get { return _Format; }
        }


        public ITriangleDataProvider Provider
        {
            get { return _Provider; }
        }
    }
}
