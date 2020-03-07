using System;
using System.Collections.Generic;
using System.Data;
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
            DataTable result = dataTable.Clone();
            DataRow newRow = result.NewRow();
            //TODO: 确保时间对表重新进行排序
            foreach (DataColumn column in dataTable.Columns) 
            {
                if (configuration.AppSettings.Settings[column.ColumnName].Value == "T")
                {
                    newRow[column.ColumnName] = dataTable.Rows[0][column.ColumnName];
                }
                else 
                {
                    switch (_processPattern)
                    {
                        case ProcessPattern.Max:
                            newRow[column.ColumnName] = MaxProcess(column);
                            break;
                        case ProcessPattern.Min:
                            newRow[column.ColumnName] = MinProcess(column);
                            break;
                        case ProcessPattern.Average:
                            newRow[column.ColumnName] = AverageProcess(column);
                            break;
                    }
                }
            }
            result.Rows.Add(newRow);
            return new DataTable();
        }


        private decimal MaxProcess(DataColumn column) 
        {
            decimal MaxValue;
            MaxValue = Convert.ToDecimal(column.Table.Rows[0][column.ColumnName]);
            for (int i = 1; i < column.Table.Rows.Count; i++)
            {
                if (MaxValue < Convert.ToDecimal(column.Table.Rows[i][column.ColumnName]))
                {
                    MaxValue = Convert.ToDecimal(column.Table.Rows[i][column.ColumnName]);
                }
            }
            return MaxValue;
        }
        private decimal MinProcess(DataColumn column)
        {
            decimal MinValue;
            MinValue = Convert.ToDecimal(column.Table.Rows[0][column.ColumnName]);
            for (int i = 1; i < column.Table.Rows.Count; i++) 
            {
                if (MinValue > Convert.ToDecimal(column.Table.Rows[i][column.ColumnName]))
                {
                    MinValue = Convert.ToDecimal(column.Table.Rows[i][column.ColumnName]);
                }
            }
            return MinValue;
        }

        private decimal AverageProcess(DataColumn column) 
        {
            decimal sum = 0;
            for (int i = 0; i < column.Table.Rows.Count; i++) 
            {
                sum += Convert.ToDecimal(column.Table.Rows[i][column.ColumnName]);
            }
            return Math.Round(sum / (column.Table.Rows.Count), 2);
        }

    }
}
