namespace WebApp.Models.Entity;

public class CategoryEntity
{
    public Guid Id { get; set; } = new Guid();
    public string CategoryName { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
