using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Models.Entity;

namespace WebApp.ViewModels;

public class ProductRegistrationViewModel
{
	[Display(Name = "Title*")]
	public string Title { get; set; } = null!;
    [Display(Name="Description (option)")]
    public string? Description { get; set; }
	[Display(Name = "Price*")]
	public decimal Price { get; set; }

	[Display(Name = "Upload Product Image(options)")]
	[DataType(DataType.Upload)]
	public IFormFile? ImageFile { get; set; }
	[Display(Name = "Category Name")]
	public string CategoryName { get; set; }=null!;

    public static implicit operator ProductEntity(ProductRegistrationViewModel viewmodel)
    {
        return new ProductEntity
        {
            Title = viewmodel.Title,
            Description = viewmodel.Description,
            Price = viewmodel.Price,
		};
    }
    public static implicit operator CategoryEntity(ProductRegistrationViewModel viewmodel)
    {
        return new CategoryEntity
        {
            CategoryName = viewmodel.CategoryName,
        };
    }
}
