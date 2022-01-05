using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CraftersCreations.Models;

namespace CraftersCreations.Data
{
    public class CraftDbContext : DbContext
    {
        public CraftDbContext()
        {

        }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Catagory> Catagory { get; set; }
        public DbSet<CraftType> CraftType { get; set; }
        public ConnectionString ConnectionString { get; set; }

        public CraftDbContext(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        public CraftDbContext(DbContextOptions<CraftDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(connectionString: ConnectionString.Value,
                new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
}
