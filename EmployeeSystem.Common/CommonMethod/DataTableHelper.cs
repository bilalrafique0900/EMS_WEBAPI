using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Common.CommonMethod
{
    public class DataTableHelper
    {
        public DataTable AddRow(DataTable Table, params object[] row)
        {
            try
            {
                DataRow tempRow = Table.NewRow();

                for (int liX = 0, liY = 1; liY < row.Length; liX = liX + 2, liY = liY + 2)
                {
                    tempRow[row[liX].ToString()] = row[liY];
                }
                Table.Rows.Add(tempRow);
                return Table;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public DataTable CreateTable(params object[] Columns)
        {
            DataTable Table = new DataTable();
            for (int i = 0; i < Columns.Length; i++)
            {
                Table.Columns.Add(Columns[i].ToString(), typeof(string));
            }
            return Table;
        }
    }
}
