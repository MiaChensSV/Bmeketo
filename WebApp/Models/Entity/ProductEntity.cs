using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.ViewModels;

namespace WebApp.Models.Entity;
[Index(nameof(ArticleNumber), IsUnique = true)]
[PrimaryKey(nameof(ArticleNumber))]

public class ProductEntity
{
    public Guid Id { get; set; }= Guid.NewGuid();

	[Display(Name = "Article Number*")]
	public string ArticleNumber { get; set; } = null!;
	public string Title { get; set; } = null!;
    public string? Description { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public Guid CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    public CategoryEntity Category { get; set; }=null!;

    public ICollection<ProductTagEntity> Tags { get; set; }=new HashSet<ProductTagEntity>();


	public static implicit operator ProductModel(ProductEntity entity)
    {
        var _productModel= new ProductModel
        {
			Id = entity.Id,
			ArticleNumber = entity.ArticleNumber,
			Title = entity.Title,
			Description = entity.Description,
			Price = entity.Price,
			ImageUrl = entity.ImageUrl,
		};

        return _productModel;
	}

}



