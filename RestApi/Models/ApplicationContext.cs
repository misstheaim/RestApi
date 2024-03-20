using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }
    }
}
