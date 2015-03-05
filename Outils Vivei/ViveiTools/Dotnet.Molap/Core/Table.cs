using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using Dotnet.Molap.Core.Columns;



namespace Dotnet.Molap.Core
{
    /// <summary>
    /// Main Data Table
    /// </summary>
    public class Table 
    {
        private Table()
        {

        } 
      
        /// <summary>
        /// 
        /// </summary>
        public ColumnCollection Columns { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int RowCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datatable"></param>
        /// <returns></returns>
        public static Table FromDataTable(DataTable datatable, string weightcolumn = null, params string[] mixedcols)
        {
            var result = new Table();
            var cols = new List<AbstractColumn>(datatable.Columns.Count);

            var counter = -1;
            for (int i = 0; i < datatable.Columns.Count; i++)
            {
                DataColumn datacolumn = datatable.Columns[i];

                AbstractColumn col = null;

                if (datacolumn.DataType == typeof(string))
                {
                    counter += 1;
                    col = new TextColumn(result, counter, datacolumn.ColumnName);
                    ((TextColumn)col).Data = new string[datatable.Rows.Count];

                    for (int j = 0; j < datatable.Rows.Count; j++)
                    {
                        col.InitializeValue(j, datatable.Rows[j][i]);
                    }

                    cols.Add(col);
                }

                if (datacolumn.DataType == typeof(DateTime))
                {
                    counter += 1;
                    col = new DateColumn(result, counter, datacolumn.ColumnName);
                    ((DateColumn)col).Data = new DateTime[datatable.Rows.Count];

                    for (int j = 0; j < datatable.Rows.Count; j++)
                    {
                        col.InitializeValue(j, datatable.Rows[j][i]);
                    }

                    cols.Add(col);
                }

                if ((datacolumn.DataType == typeof(double))
                    || (datacolumn.DataType == typeof(long))
                    || (datacolumn.DataType == typeof(float))
                    || (datacolumn.DataType == typeof(int)))
                {
                    counter += 1;
                    col = new NumberColumn(result, counter, datacolumn.ColumnName);
                    ((NumberColumn)col).Data = new double[datatable.Rows.Count];

                    for (int j = 0; j < datatable.Rows.Count; j++)
                    {
                        col.InitializeValue(j, datatable.Rows[j][i]);
                    }

                    cols.Add(col);
                }


            }

            result.Columns = new ColumnCollection(result, cols);
            result.RowCount = datatable.Rows.Count;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Table FromCubeFile(string filename)
        {
            return null;
        }

        private void SaveBinary(string filename)
        {

            var fs = System.IO.File.Open(filename, System.IO.FileMode.Truncate);

            var bw = new System.IO.BinaryWriter(fs);

            bw.Write(RowCount);
            bw.Write(Columns.Count);

            foreach (var c in Columns)
            {
                bw.Write(c.Name);
                if (c.GetType() == typeof(TextColumn))
                {
                    bw.Write(1);
                }
                if (c.GetType() == typeof(NumberColumn))
                {
                    bw.Write(2);
                }
                if (c.GetType() == typeof(DateColumn))
                {
                    bw.Write(3);
                }
            }
            foreach (var c in Columns)
            {
                if (c.GetType() == typeof(TextColumn))
                {
                    for (int i = 0; i < RowCount; i++)
                    {
                        bw.Write(((TextColumn)c).Data[i]);
                    }
                }
                if (c.GetType() == typeof(NumberColumn))
                {
                    byte[] buf = new byte[8 * RowCount];

                    Buffer.BlockCopy(((NumberColumn)c).Data, 0, buf, 0, 8 * RowCount);

                    bw.Write(buf);

                    buf = null;
                }
                if (c.GetType() == typeof(DateColumn))
                {
                    for (int i = 0; i < RowCount; i++)
                    {
                        bw.Write(((DateColumn)c).Data[i].ToBinary());
                    }
                }
            }

            bw.Close();
            bw.Dispose();
            fs.Close();
            fs.Dispose();

            GC.Collect();
        }

        public void Save(string filename, int rowcount = -1)
        {


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Column"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetValue(AbstractColumn Column, int index)
        {
            return Column.GetValue(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public object GetValue(int ColumnIndex, int index)
        {
            return this.Columns.GetColumn(ColumnIndex).GetValue(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Column"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFormattedValue(AbstractColumn Column, int index)
        {
            return Column.GetFormattedValue(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ColumnIndex"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetFormattedValue(int ColumnIndex, int index)
        {
            return this.Columns.GetColumn(ColumnIndex).GetFormattedValue(index);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="functor"></param>
        /// <returns></returns>
        public AbstractColumn AddColumn<T>(string name, T[] data)
        {
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        public void Refresh(DataTable table)
        {

        }

       
    }
}
