using Microsoft.EntityFrameworkCore;
using SmallApplication_EF;

namespace SmallApplication_EF
{
    public class DBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db");
        }
    }

}