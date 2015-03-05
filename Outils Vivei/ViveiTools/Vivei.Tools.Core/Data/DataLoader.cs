using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vivei.Dashboard.Tools.Core
{
    public   class DataLoader
    {

        public object LoadSasTable(string filename)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder conbuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();

            conbuilder.Provider = "sas.LocalProvider";
            conbuilder.DataSource = System.IO.Path.GetDirectoryName(filename);
            var cmd = new System.Data.OleDb.OleDbCommand(System.IO.Path.GetFileNameWithoutExtension(filename), new System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString));

            cmd.CommandType = System.Data.CommandType.TableDirect;


            return null;
        }
        public object LoadSqlCE(string filename, string range)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder conbuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();

            conbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            conbuilder.DataSource = filename;
            conbuilder.Add("Extended Properties", "Excel 8.0;HDR=YES");

            var cmd = new System.Data.OleDb.OleDbCommand(range, new System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString));

            cmd.CommandType = System.Data.CommandType.TableDirect;
            return ReadOnlyTable.LoadFromCommand(cmd);
        }
        public object LoadExcel2003(string filename, string range)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder conbuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();

            conbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            conbuilder.DataSource = filename;
            conbuilder.Add("Extended Properties", "Excel 8.0;HDR=YES");

            var cmd = new System.Data.OleDb.OleDbCommand(range, new System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString));

            cmd.CommandType = System.Data.CommandType.TableDirect;
            return ReadOnlyTable.LoadFromCommand(cmd);
        }
        public object LoadExcel2007(string filename, string range)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder conbuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();

            conbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            conbuilder.DataSource = filename;
            conbuilder.Add("Extended Properties", "Excel 12.0 Xml;HDR=YES");

            var cmd = new System.Data.OleDb.OleDbCommand(range, new System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString));

            cmd.CommandType = System.Data.CommandType.TableDirect;

            ReadOnlyTable result = ReadOnlyTable.LoadFromCommand(cmd);

            result.Save(
                System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filename), 
                System.IO.Path.GetFileNameWithoutExtension(filename) + ".data"));

            return result;
        }
        public object LoadExcel2007Macro(string filename, string range)
        {
            System.Data.OleDb.OleDbConnectionStringBuilder conbuilder = new System.Data.OleDb.OleDbConnectionStringBuilder();

            conbuilder.Provider = "Microsoft.ACE.OLEDB.12.0";
            conbuilder.DataSource = filename;
            conbuilder.Add("Extended Properties", "Excel 12.0 Macro;HDR=YES");

            var cmd = new System.Data.OleDb.OleDbCommand(range, new System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString));

            cmd.CommandType = System.Data.CommandType.TableDirect;
            return ReadOnlyTable.LoadFromCommand(cmd);
        }
        public object LoadCsv(string filename, string range, string separator)
        {
            return null;
        }
    }
}
