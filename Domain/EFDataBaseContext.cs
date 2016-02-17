using System.Data.Entity;
using Domain.Entities;

namespace Domain
{
    public class EfDataBaseContext : DbContext
    {
        public EfDataBaseContext(string connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Play> Plays { get; set; }
    }
}
