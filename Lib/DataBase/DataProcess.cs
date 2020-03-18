using Lib.DataBase.Model;
using System;
using System.Configuration;
using System.Data;

namespace Lib.DataBase
{
    public class DataProcess
    {
        private ProcessPattern _processPattern;

        public DataProcess(ProcessPattern pattern)
        {
            _processPattern = pattern;
        }

        public void SetProcessPattern(ProcessPattern pattern)
        {
            _processPattern = pattern;
        }

        public DataTable Process(DataTable dataTable)
        {
            DataTable result = dataTable.Clone();
            if (dataTable.Rows.Count == 0)
            {
                return dataTable;
            }
            DataRow newRow = result.NewRow();
            //TODO: 确保时间对表重新进行排序
            foreach (DataColumn column in dataTable.Columns)
            {
                if (ConfigurationManager.AppSettings[column.ColumnName] == "T")
                {
                    newRow[column.ColumnName] = dataTable.Rows[0][column.ColumnName];
                }
                else if(ConfigurationManager.AppSettings[column.ColumnName] == "S")
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
                        case ProcessPattern.Latest:
                            newRow[column.ColumnName] = LatestProcess(column);
                            break;
                    }
                }
            }
            result.Rows.Add(newRow);
            return result;
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
            return Math.Round(sum / (column.Table.Rows.Count), 1);
        }

        private decimal LatestProcess(DataColumn column)         
        {
            return Convert.ToDecimal(column.Table.Rows[column.Table.Rows.Count - 1][column.ColumnName]);
        }

    }
}
