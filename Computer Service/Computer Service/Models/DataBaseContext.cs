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
            const string connectionString = "Server=127.0.0.1;Database=computer_service;Uid=root;Pwd=P@ssw0rd;";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
