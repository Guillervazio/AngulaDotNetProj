using Microsoft.EntityFrameworkCore;

namespace APIService.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Person> Persons => Set<Person>();
    }
}
