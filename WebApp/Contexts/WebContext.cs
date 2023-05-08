using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entity;

namespace WebApp.Contexts;

public class WebContext:DbContext
{
    public WebContext(DbContextOptions<WebContext> options) : base(options)
    {
    }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductTagEntity> ProductTags { get; set; }    
    public DbSet<TagEntity> Tags { get; set; }  
    public DbSet<ShowcaseEntity> Showcases { get; set; }

}
