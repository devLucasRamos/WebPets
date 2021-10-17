using Microsoft.EntityFrameworkCore;
using System;
using WebPets.Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pets> Pets { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite(connectionString: "DataSource=petsdb.db;Cache=Shared");

    }
}