using Lib.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Lib.DataBase
{
    public class SqlServerConnection
    {

        /// <summary>
        /// 将DataTable写入数据库的表中
        /// </summary>
        /// <param name="source">数据源DataTable</param>
        /// <param name="tableName">数据目标的表名</param>
        /// <param name="useTransaction">操作过程是否使用事务</param>
        /// <param name="databaseConnString">数据库连接字符串</param>
        /// <param name="dropTable">删除DB中已存在的表(并自动新建表)</param>
        /// <param name="primaryKeys">主键的列名</param>github
        private static bool WriteToDataBase(DataTable source, string tableName, bool useTransaction = true, bool dropTable = false)
        {
            try
            {
                string sql = "select * from sys.objects where type='U' and name='" + tableName + "'";
                DataTable dt = Query(sql);
                if (dt.Rows.Count > 0)
                {
                    if (dropTable == true)
                    {
                        sql = "drop table " + tableName + "";   //清除已存在的表
                        ExecuteNonQuery(sql);
                    }
                    else
                    {
                        SqlBulkCopy sqlbulkcopy = new SqlBulkCopy(GetSqlConnectionString(), SqlBulkCopyOptions.UseInternalTransaction);
                        sqlbulkcopy.DestinationTableName = tableName;//数据库中的表名

                        sqlbulkcopy.WriteToServer(source);
                        return true;
                    }
                }
                ExecuteNonQuery(CreateTable(source, tableName));
                var sqlBulkCopy = new System.Data.SqlClient.SqlBulkCopy(GetSqlConnectionString(), SqlBulkCopyOptions.FireTriggers);//启动触发器
                if (useTransaction == true)
                {
                    sqlBulkCopy = new System.Data.SqlClient.SqlBulkCopy(GetSqlConnectionString(), SqlBulkCopyOptions.UseInternalTransaction | SqlBulkCopyOptions.FireTriggers); //导入的数据在一个事务中 
                }
                sqlBulkCopy.DestinationTableName = tableName;
                foreach (DataColumn c in source.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                }
                //SqlBulkCopy.BulkCopyTimeout = this.timeout;  //超时时间 
                sqlBulkCopy.BatchSize = 3000;  //每次传输3000行 
                sqlBulkCopy.WriteToServer(source);
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public static string CreateTable(DataTable table, string tableName) 
        {
            var colList = new List<string>();

            foreach (DataColumn column in table.Columns) 
            {
                string type = GetTableColumnType(column.DataType);
                string isautoIn = column.AutoIncrement ? $"IDENTITY({column.AutoIncrementSeed},{column.AutoIncrementStep})" : "";
                string isNull = column.AllowDBNull ? "NULL" : "NOT NULL";
                string columnString = $"[{column.ColumnName}] [{type}] {isautoIn} {isNull}";
                colList.Add(columnString);
            }
            string sql = string.Format(@" if object_id('0') is not null begin truncate table {0} drop table {0} end CREATE TABLE {0}({1}) ON [PRIMARY];", tableName, string.Join(",", colList.ToArray()));
            return sql;
        }

        private static string GetTableColumnType(System.Type type)
        {
            string result = "text";
            string sDbType = type.ToString();
            switch (sDbType)
            {
                case "System.String":
                    break;
                case "System.Int16":
                    result = "int";
                    break;
                case "System.Int32":
                    result = "int";
                    break;
                case "System.Int64":
                    result = "float";
                    break;
                case "System.Decimal":
                    result = "numeric";
                    break;
                case "System.Double":
                    result = "numeric";
                    break;
                case "System.DateTime":
                    result = "datetime";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(GetSqlConnectionString()))
            {
                using (SqlCommand comm = conn.CreateCommand())
                {
                    conn.Open();
                    comm.CommandText = sql;
                    return comm.ExecuteNonQuery();
                }
            }
        }

        private static DataTable Query(string sql) 
        {
            SqlConnection sqlConnection = new SqlConnection(GetSqlConnectionString());
            DataSet dataSet = new DataSet();
            try
            {
                sqlConnection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);
                dataAdapter.Fill(dataSet);
            }
            catch
            {

            }
            finally 
            {
                if (sqlConnection.State == ConnectionState.Open) 
                {
                    sqlConnection.Close();
                }
            }
            return dataSet.Tables[0];
        }

        private static string GetSqlConnectionString() 
        {
            return "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }


        public static bool WriteDataToDB(DataWrapper wrapper) 
        {
            DataTable onOffRecord = wrapper._onOffRecord;
            onOffRecord = addPrimaryKey(onOffRecord, new string[] { "ClientName", "MCGS_Time" }, wrapper.clientName);

            DataTable tmpAndMoistData = wrapper._tmpAndMoistData;
            tmpAndMoistData = addPrimaryKey(tmpAndMoistData, new string[] { "ClientName", "MCGS_Time" }, wrapper.clientName);

            WriteToDataBase(onOffRecord, "开关量存盘_MCGS");
            WriteToDataBase(tmpAndMoistData, "温湿度数据_MCGS");
            return true;
        }

        private static DataTable addPrimaryKey(DataTable dataTable, string[] KeyNames, string ClientName) 
        {
            if (dataTable.PrimaryKey.Length != 0)
            {
                return dataTable;
            }
            else 
            {
                DataColumn[] primaryKeys = new DataColumn[KeyNames.Length];
                for (int i = 0; i < KeyNames.Length; i++)
                {
                    if (!dataTable.Columns.Contains(KeyNames[i]))
                    {
                        //没有此主键, 创建并添加列
                        DataColumn newColumn = new DataColumn(KeyNames[i]);
                        newColumn.DefaultValue = ClientName;
                        dataTable.Columns.Add(newColumn);
                    }
                    primaryKeys[i] = dataTable.Columns[KeyNames[i]];
                }
                dataTable.Constraints.Add(new UniqueConstraint("PK", primaryKeys));
                dataTable.PrimaryKey = primaryKeys;
                return dataTable;
            }
        }
        public int BatchAdd(DataWrapper wrapper) 
        {
            int result = 1;
            SqlConnection sqlConnection = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
            try
            {
                sqlConnection.Open();
                SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnection);
                
                sqlBulk.DestinationTableName = "开关量存盘_MCGS";
                sqlBulk.WriteToServer(wrapper._onOffRecord);

                sqlBulk.DestinationTableName = "温湿度数据_MCGS";
                sqlBulk.WriteToServer(wrapper._tmpAndMoistData);
            }
            catch (Exception e)
            {
                result = 0;
            }
            finally 
            {
                sqlConnection.Close();
            }
            return result;
        }
    }
}
