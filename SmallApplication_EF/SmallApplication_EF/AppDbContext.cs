using Microsoft.EntityFrameworkCore;

namespace SmallApplication_EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=people.db");
        }
    }
}