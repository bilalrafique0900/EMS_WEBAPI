using MySqlConnector;
using System.Data;

namespace EmployeeSystem.Infra.MySql
{
    public class MySql : IMysql
    {
        private readonly string _connectionString;
        public MySql(string connectionString)
        {
            _connectionString = connectionString;

        }
        public async Task<DataTable> GetDataTable(string query)
        {
            DataTable dt = new();
            using MySqlConnection conn = new(_connectionString);
            await conn.OpenAsync();
            MySqlCommand mySqlCommand = new(query, conn);
            MySqlCommand cmd = mySqlCommand;
            cmd.CommandType = CommandType.Text;
            using (MySqlDataAdapter sda = new(cmd))
            {
                sda.Fill(dt);
            }
            return dt;
        }
    }
}
