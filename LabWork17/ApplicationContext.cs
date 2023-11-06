using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork17
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder = new()
            {
                DataSource = "localhost\\SQLEXPRESS", //"prserver\\SQLEXPRESS";
                InitialCatalog = "LabWork5", //"ispp1103";
                UserID = "", //"ispp1103";
                Password = "", //"1103";
                TrustServerCertificate = true,
                IntegratedSecurity = true
            };
            var connectionString = builder.ToString();

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> SelectFromProducts()
        {
            using var context = new ApplicationContext();
            return context.Products;
        }
    }
}
