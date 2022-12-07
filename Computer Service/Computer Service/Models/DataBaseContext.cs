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
            const string connectionString = "Server=tcp:pwr-bd.database.windows.net,1433;Initial Catalog=Computer Service;Persist Security Info=False;User ID=mprzenzak;Password=P@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
