using Microsoft.EntityFrameworkCore;
using System;

namespace SmallApplication_EF
{
    public class DBContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=people.db");
        }
    }
}