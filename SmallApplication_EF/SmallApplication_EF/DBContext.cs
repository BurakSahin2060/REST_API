using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmallApplication_EF;

namespace SmallApplication_EF
{
    public class DBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }

        private static readonly ILoggerFactory _loggerFactory = 
        LoggerFactory.Create(builder =>
    {
        builder
            .AddConsole()
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name &&
                level == LogLevel.Information);
    });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mydatabase.db")
            .UseLoggerFactory(_loggerFactory);
        }
    }

}