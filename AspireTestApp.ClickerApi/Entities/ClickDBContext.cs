using Microsoft.EntityFrameworkCore;

namespace ClickerApi.Entities
{
    public class ClickerDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public ClickerDBContext(DbContextOptions<ClickerDBContext> options) 
            :base(options)
        {
            Database.EnsureCreated();
        }

        public ClickerDBContext() 
            :base()
        {
            Database.EnsureCreated();
        }
    }
}