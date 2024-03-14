using System.Data;

namespace EmployeeSystem.Infra.MySql
{
    public interface IMysql
    {
        Task<DataTable> GetDataTable(string query);
    }
}
