using Microsoft.EntityFrameworkCore;
using System;

namespace Computer_Service.Models
{
    [Serializable]
    public class DataBaseContext : DbContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionStringold = "Server=tcp:pwr-bd.database.windows.net,1433;Initial Catalog=Computer Service;Persist Security Info=False;User ID=mprzenzak;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            const string connectionString3 = "server=root@127.0.0.1:3306;database=computer_service;user=root;password=P@ssw0rd";
            const string connectionString = "Server=127.0.0.1;Database=computer_service;Uid=root;Pwd=P@ssw0rd;";
            //root@127.0.0.1:3306
            //    jdbc: mysql://127.0.0.1:3306/?user=root
            //optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
