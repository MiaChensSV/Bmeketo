using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entity;

namespace WebApp.Contexts
{
    public class WebContext:DbContext
    {
        public WebContext(DbContextOptions<WebContext> options) : base(options)
        {
        }

        public DbSet<ShowcaseEntity> Showcases { get; set; }

    }
}
