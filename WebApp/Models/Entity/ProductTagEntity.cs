using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entity;
[PrimaryKey(nameof(ProductId), nameof(TagId))]

public class ProductTagEntity
{
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
    public int TagId { get; set; } 
    public TagEntity Tag { get; set; }=null!;
}


