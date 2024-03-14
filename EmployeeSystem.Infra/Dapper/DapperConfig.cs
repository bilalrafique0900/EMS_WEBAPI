using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace EmployeeSystem.Infra.Dapper
{
    public class DapperConfig: IDapperConfig
    {
        public IConfiguration _configuration { get; }
        private string _con { get; set; }
        public DapperConfig(IConfiguration configuration)
        {
            _configuration = configuration;
            _con = _configuration.GetConnectionString("ServerConnection");
            //SqlMapper.AddTypeHandler(new TimeTypeHandler());
        }
        public IDbConnection CreateConnection()
        => new SqlConnection(_con);
        public List<T> Query<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.Query<T>(query, parameter, null, true, null, commandType).ToList();
            }
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (var conn = new SqlConnection(_con))
            {
                await conn.OpenAsync();
                return await conn.QueryAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QueryFirst<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QueryFirst<T>(query, parameter, null, null, commandType);
            }
        }

        public Task<T> QueryFirstAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QueryFirstAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QueryFirstOrDefault<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QueryFirstOrDefault<T>(query, parameter, null, null, commandType);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (var conn = new SqlConnection(_con))
            {
                await conn.OpenAsync();
                return await conn.QueryFirstOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QuerySingle<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QuerySingle<T>(query, parameter, null, null, commandType);
            }
        }

        public Task<T> QuerySingleAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QuerySingleAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T QuerySingleOrDefault<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QuerySingleOrDefault<T>(query, parameter, null, null, commandType);
            }
        }

        public Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : class
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.QuerySingleOrDefaultAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public T ExecuteScalar<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : IConvertible
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.ExecuteScalar<T>(query, parameter, null, null, commandType);
            }
        }

        public Task<T> ExecuteScalarAsync<T>(string query, object parameter = null, CommandType commandType = CommandType.Text) where T : IConvertible
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.ExecuteScalarAsync<T>(query, parameter, null, null, commandType);
            }
        }

        public int ExecuteQuery(string query, object parameter = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.Execute(query, parameter, null, null, commandType);
            }
        }

        public Task<int> ExecuteQueryAsync(string query, object parameter = null, CommandType commandType = CommandType.Text)
        {
            using (IDbConnection db = new SqlConnection(_con))
            {
                return db.ExecuteAsync(query, parameter, null, null, commandType);
            }
        }

        public async Task<DataTable> GetDataTableAsync(string query, object[] parameters , CommandType commandType = CommandType.Text) 
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (var conn = new SqlConnection(_con))
                {
                    using (SqlCommand sqlCommand = new())
                    {
                       
                        using (SqlDataAdapter sqlDataAdapter = new())
                        {
                            sqlCommand.CommandText = query;
                            sqlCommand.CommandType = commandType;
                            sqlCommand.Parameters.AddRange(parameters);
                            sqlCommand.Connection = conn;
                            sqlDataAdapter.SelectCommand = sqlCommand;
                            await Task.Run(() => sqlDataAdapter.Fill(dataTable));
                        }
                    }
                }
                return dataTable;
            }
            catch (Exception)
            {

                throw;
            }
           
        }



    }
}
