using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CraftersCreations.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CraftersCreations.Data
{
    public class CraftDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Materials>().Property(e => e.CraftTypeId).IsRequired();
            modelBuilder.Entity<Materials>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Projects>().Property(e => e.CatagoryId).IsRequired();
            modelBuilder.Entity<Projects>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<CraftType>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Catagory>().Property(e => e.Name).IsRequired();
            base.OnModelCreating(modelBuilder);
        } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(connectionString: ConnectionString.Value,
                new MySqlServerVersion(new Version(8, 0, 26)));
        }
    }
}
