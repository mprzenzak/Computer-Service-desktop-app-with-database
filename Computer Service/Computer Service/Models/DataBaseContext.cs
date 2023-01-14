using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Computer_Service.Models
{
    [Serializable]
    public class DataBaseContext : DbContext
    {
        private StringBuilder connectionString;
        public DataBaseContext(string userType)
        {
            this.connectionString = new StringBuilder("Server=127.0.0.1;Database=computer_service;Uid=" + userType + ";Pwd=P@ssw0rd;");
        }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<Repair> Repairs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connectionString.ToString());
        }
    }
}
