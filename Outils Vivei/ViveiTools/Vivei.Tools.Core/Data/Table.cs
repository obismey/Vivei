using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Vivei.Dashboard.Tools.Core
{
    public class ReadOnlyTable
    {
        public IEnumerable<Column> Columns { get { return this.columnData; } }

        public int ColumnCount { get { return this.columnData.Length; } }

        public int RowCount { get; internal set; }

        public Column GetColumn(string name)
        {
            return columnData[columnNameData[name]];
        }
        public Column GetColumn(int index)
        {
            return columnData[index];
        }

        public void Save(string filename)
        {
            var f = System.IO.File.Open(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.Write);

            var colbuffer = new byte[4 * this.RowCount];

            //var writer = new System.IO.Compression.GZipStream(f, System.IO.Compression.CompressionMode.Compress);

            //var writer = new System.IO.BinaryWriter(f);

            var writer = new ICSharpCode.SharpZipLib.Zip.ZipOutputStream(f);

            writer.PutNextEntry(new ICSharpCode.SharpZipLib.Zip.ZipEntry("RowData"));
            writer.Write(BitConverter.GetBytes(this.ColumnCount), 0, 4);
            writer.Write(BitConverter.GetBytes(this.RowCount), 0, 4);


            foreach (var col in this.columnData)
            {
                Buffer.BlockCopy(col.Rows, 0, colbuffer, 0, Buffer.ByteLength(col.Rows));

                writer.Write(colbuffer, 0, colbuffer.Length);
            }
            writer.CloseEntry();

            var encoder = new System.Text.UTF8Encoding();

            foreach (var col in this.columnData)
            {
                //writer.Write(col.Values.Length);
                //writer.Write((int)col.Type);
                writer.PutNextEntry(new ICSharpCode.SharpZipLib.Zip.ZipEntry(col.Name));
                writer.Write(BitConverter.GetBytes(col.Values.Length), 0, 4);
                writer.Write(BitConverter.GetBytes((int)col.Type), 0, 4);
                writer.Write(BitConverter.GetBytes(col.Index), 0, 4);

                if (col.Type == TypeCode.String)
                {
                    var bytesize = 0;
                    var newlinebytesize = encoder.GetByteCount(Environment.NewLine);
                    for (int i = 0; i < col.Values.Length; i++)
                    {
                        bytesize += (newlinebytesize + encoder.GetByteCount((string)col.Values[i]));
                    }
                    byte[] colvaluebuffer = new byte[bytesize];
                    bytesize = 0;
                    for (int i = 0; i < col.Values.Length; i++)
                    {
                        encoder.GetBytes((string)col.Values[i]).CopyTo(colvaluebuffer, bytesize);
                        bytesize += encoder.GetByteCount((string)col.Values[i]);
                        encoder.GetBytes(Environment.NewLine).CopyTo(colvaluebuffer, bytesize);
                        bytesize += newlinebytesize;
                    }
                    writer.Write(colvaluebuffer, 0, colvaluebuffer.Length);
                    colvaluebuffer = null;
                }
                else
                {
                    byte[] colvaluebuffer = new byte[col.Values.Length * 8];
                    for (int i = 0; i < col.Values.Length; i++)
                    {
                        BitConverter.GetBytes(Convert.ToDouble(col.Values[i])).CopyTo(colvaluebuffer, i * 8);
                    }
                    writer.Write(colvaluebuffer, 0, colvaluebuffer.Length);
                    colvaluebuffer = null;
                }
                writer.CloseEntry();
            }

            writer.Finish();
            writer.Close();
            f.Close();

            colbuffer = null;

            GC.Collect();
        }

        public ReadOnlyTable Load(string filename)
        {
            return null;
        }

        private SortedList<string, int> columnNameData;
        private Column[] columnData;

        public object this[int rowindex, int columnindex]
        {
            get
            {
                var valueindex = this.columnData[columnindex].Rows[rowindex];
                return valueindex == 0 ? null : this.columnData[columnindex].Values[valueindex - 1];
            }
        }
        public object this[int rowindex, string columnname]
        {
            get
            {
                var valueindex = this.columnData[columnNameData[columnname]].Rows[rowindex];
                return valueindex == 0 ? null : this.columnData[columnNameData[columnname]].Values[valueindex - 1];
            }
        }

        public static ReadOnlyTable LoadFromCommand(System.Data.Common.DbCommand cmd)
        {
            var result = new ReadOnlyTable();

            cmd.Connection.Open();

            var reader = cmd.ExecuteReader();

            result.columnData = new Column[reader.FieldCount];
            result.columnNameData = new SortedList<string, int>(reader.FieldCount);
            var lookupdata = new Lookup<object, int>[reader.FieldCount];

            for (int i = 0; i < reader.FieldCount; i++)
            {
                result.columnData[i] = new Column()
                {
                    Name = reader.GetName(i),
                    Index = i,
                    Type = Type.GetTypeCode(reader.GetFieldType(i))
                };

                result.columnNameData.Add(result.columnData[i].Name, i);

                lookupdata[i] = new Lookup<object, int>(null);
            }

            int rowcount = 0;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            lookupdata[i].GetGrouping(reader.GetValue(i), true).Add(rowcount);
                        }
                    }

                    rowcount += 1;
                }
            }
            cmd.Connection.Close();

            result.RowCount = rowcount;

            foreach (var c in lookupdata)
            {
                rowcount = 0;
                foreach (var g in c)
                {
                    Array.Resize(ref g.elements, g.count);
                    c.groupings[rowcount] = g;
                    rowcount += 1;
                }
                Array.Resize(ref c.groupings, c.count);
                Array.Sort(c.groupings, new Lookup<object, int>.GroupingComparer());
            }

            for (int i = 0; i < result.ColumnCount; i++)
            {
                //rowcount = 0;
                result.columnData[i].Values = new object[lookupdata[i].count];
                result.columnData[i].Rows = new int[result.RowCount];

                for (int j = 0; j < lookupdata[i].count; j++)
                {
                    result.columnData[i].Values[j] = lookupdata[i].groupings[j].key;

                    for (int k = 0; k < lookupdata[i].groupings[j].count; k++)
                    {
                        result.columnData[i].Rows[lookupdata[i].groupings[j].elements[k]] = j + 1;
                    }
                }
            }


            lookupdata = null;
            GC.Collect();




            return result;
        }

    }

    public class Column
    {
        public string Name { get; internal set; }
        public int Index { get; internal set; }
        public TypeCode Type { get; internal set; }
        public object[] Values { get; internal set; }
        public int[] Rows { get; internal set; }
    }



}
