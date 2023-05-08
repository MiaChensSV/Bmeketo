namespace WebApp.Models.Entity;

public class TagEntity
{
    public int Id { get; set; }
    public string TagName { get; set; } = null!;
    public ICollection<ProductTagEntity> Products { get; set; }=new HashSet<ProductTagEntity>();
}


