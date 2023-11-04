using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork16
{
    public class DapperDataContext
    {
        private string _serverName = "localhost\\SQLEXPRESS"; //"prserver\\SQLEXPRESS";
        private string _dbName = "LabWork5"; //"ispp1103";
        private string _userName = ""; //"ispp1103";
        private string _password = ""; //"1103";
        private bool _integratedSecurity = true;

        public string ConnectionString => new SqlConnectionStringBuilder()
        {
            TrustServerCertificate = true,
            DataSource = _serverName,
            InitialCatalog = _dbName,
            UserID = _userName,
            Password = _password,
            IntegratedSecurity = _integratedSecurity
        }.ConnectionString;

        public List<Product>? Products
        {
            get
            {
                using IDbConnection connection = new SqlConnection(ConnectionString);
                string query = "SELECT * FROM Product";
                return connection.Query<Product>(query).ToList();
            }
        }
    }
}
