using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace Lib.DataBase.Tests
{
    [TestClass()]
    public class DataProcessTests
    {
        [TestMethod()]
        public void DataProcessTest()
        {
            DataTable table = new DataTable();
            table.Columns.Add("MCGS_Time", Type.GetType("System.DateTime"));
            table.Columns.Add("MCGS_TimeMS", Type.GetType("System.Single"));

            DataRow newRow1 = table.NewRow();
            newRow1[0] = DateTime.Now;
            newRow1[1] = 15;

            DataRow newRow2 = table.NewRow();
            newRow2[0] = DateTime.Now.AddDays(-1);
            newRow2[1] = 15;

            table.Rows.Add(newRow1);
            table.Rows.Add(newRow2);
        }
    }
}