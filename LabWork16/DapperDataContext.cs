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
        //private string _serverName = "prserver\\SQLEXPRESS";
        //private string _dbName = "ispp1103";
        //private string _userName = "ispp1103";
        //private string _password = "1103";

        public string ConnectionString => new SqlConnectionStringBuilder()
        {
            TrustServerCertificate = true,
            DataSource = "prserver\\SQLEXPRESS",
            InitialCatalog = "ispp1103",
            UserID = "ispp1103",
            Password = "1103",
        }.ConnectionString;

        public List<Product>? Products
        {
            get
            {
                return GetProducts();
            }
        }

        private List<Product> GetProducts()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Product";
                return connection.Query<Product>(query).ToList();
            }
        }
    }
}
