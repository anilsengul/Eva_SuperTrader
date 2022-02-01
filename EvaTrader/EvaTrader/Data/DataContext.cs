using Microsoft.EntityFrameworkCore;

namespace EvaTrader.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Share> Share { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }

    }
}
