using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
    public DbSet<OrderRowEntity> OrderRows { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<InvoiceRowEntity> InvoiceRows { get; set; }
    public DbSet<InvoiceEntity> Invoices { get; set; }
    public DbSet<ContactFormEntity> ContactForms { get; set; }
}
