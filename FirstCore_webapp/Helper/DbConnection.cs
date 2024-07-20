using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System;
using Dapper;
using Microsoft.Extensions.Options;

namespace FirstCore_webapp.Helper
{
    public class DbConnection
    {

        //internal static string ConnectionStrings = Startup.Connection.CompanyDB;

        internal static string ConnectionString = Startup.ConnectionString.ToString();

        internal static IEnumerable<T> Query<T>(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Query<T>(sql, param);
            }
        }

        internal static int Execute(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.Execute(sql, param);
            }
        }

        internal static T ExecuteScalar<T>(string sql, object param = null)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                return conn.ExecuteScalar<T>(sql, param);
            }
        }

        internal static void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        //DapperORM.ExecuteReturnScalar<int>(_,_);
        internal static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
            }

        }
        //DapperORM.ReturnList<EmployeeModel> <=  IEnumerable<EmployeeModel>
        internal static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}