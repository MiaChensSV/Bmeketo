using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entity;

namespace WebApp.Data
{
    public class DataContext:DbContext
    {
		
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ShowcaseEntity> Showcases { get; set; }
    }
}
