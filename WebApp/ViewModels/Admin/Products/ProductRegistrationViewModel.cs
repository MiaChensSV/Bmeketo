using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Entity;

namespace WebApp.ViewModels.Admin.Products;
[Index(nameof(ArticleNumber), IsUnique = true)]
public class ProductRegistrationViewModel
{   
	[Display(Name = "Article Number*")]
	[Required(ErrorMessage = "Article Number must be unique")]
	public string ArticleNumber { get; set; } = null!;

	[Display(Name = "Title*")]
	[Required(ErrorMessage = "Title is required")]
	public string Title { get; set; } = null!;
    [Display(Name = "Description (option)")]
    public string? Description { get; set; }
    [Display(Name = "Price (i SEK)*")]
	[Required(ErrorMessage = "Price is required")]
	public decimal Price { get; set; }

    [Display(Name = "Upload Product Image(options)")]
    [DataType(DataType.Upload)]
    public IFormFile? ImageFile { get; set; }
    [Display(Name = "Category Name")]
	[Required(ErrorMessage = "CategoryName is required")]
	public string CategoryName { get; set; } = null!;
    public string? CatagoryId { get; set; }

    public static implicit operator ProductEntity(ProductRegistrationViewModel viewmodel)
    {
        return new ProductEntity
        {
            ArticleNumber = viewmodel.ArticleNumber,
            Title = viewmodel.Title,
            Description = viewmodel.Description,
            Price = viewmodel.Price,
            ImageUrl = viewmodel.ImageFile?.FileName,
            CategoryId = Guid.Parse(viewmodel.CatagoryId!),
        };
    }
	public static implicit operator CategoryEntity(ProductRegistrationViewModel viewmodel)
	{
		return new CategoryEntity
		{
			CategoryName= viewmodel.CategoryName,
		};
	}

}
