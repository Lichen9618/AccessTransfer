using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lib.DataBase.Model;
using System.Configuration;

namespace Lib.DataBase
{
    public class DataProcess
    {
        private ProcessPattern _processPattern;
        private Configuration configuration;
        public DataTable Table;

        public DataProcess(string path) 
        {
            path = "D:\\project\\cui\\code\\AccessTransfer\\Lib\\Config\\App.exe";
            configuration = ConfigurationManager.OpenExeConfiguration(path);
        }

        public void SetProcessPattern(ProcessPattern pattern) 
        {
            _processPattern = pattern;
        }

        public DataTable Process(DataTable dataTable) 
        {
            foreach (DataColumn column in dataTable.Columns) 
            {
                switch (_processPattern) 
                {
                    case ProcessPattern.Max:
                        break;
                    case ProcessPattern.Min:
                        break;
                    case ProcessPattern.Average:
                        break;
                }

                if (configuration.AppSettings.Settings[column.ColumnName].Value == "T") 
                {

                }
            }
            return new DataTable();
        }


        private float MaxProcess(DataColumn column) 
        {
            float MaxValue = MaxValue = (float)column.Table.Rows[0][column.ColumnName];
            for (int i = 1; i < column.Table.Rows.Count; i++)
            {
                if (MaxValue < (float)column.Table.Rows[i][column.ColumnName])
                {
                    MaxValue = (float)column.Table.Rows[i][column.ColumnName];
                }
            }
            return MaxValue;
        }
        private float MinProcess(DataColumn column)
        {
            float MinValue = MinValue = (float)column.Table.Rows[0][column.ColumnName];
            for (int i = 1; i < column.Table.Rows.Count; i++) 
            {
                if (MinValue > (float)column.Table.Rows[i][column.ColumnName])
                {
                    MinValue = (float)column.Table.Rows[i][column.ColumnName];
                }
            }
            return MinValue;
        }

    }
}
