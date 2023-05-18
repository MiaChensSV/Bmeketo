using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entity;
using System.Runtime.CompilerServices;
using WebApp.ViewModels.Admin.Products;

namespace WebApp.Models;

public class ProductModel
{
	public Guid Id { get; set; } 
	public string ArticleNumber { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public decimal Price { get; set; }
	public string? ImageUrl { get; set; }
	public string CategoryName { get; set; } = null!;
	public List<string> Tags { get; set; } = new List<string>();

	public static implicit operator ProductEntity(ProductModel model)
	{
		var _productEntity = new ProductEntity
		{
			ArticleNumber = model.ArticleNumber,
			Title = model.Title,
			Description = model.Description,
			Price = model.Price,
			ImageUrl = model.ImageUrl,
		};
		return _productEntity;
	}
	public static implicit operator CategoryEntity(ProductModel model)
	{
		var _categoryEntity = new CategoryEntity
		{
			CategoryName = model.CategoryName,
		};
		return _categoryEntity;
	}
	public static implicit operator ProductRegistrationViewModel(ProductModel model)
	{
		var _productRegistrationViewModel = new ProductRegistrationViewModel
		{
			ArticleNumber = model.ArticleNumber,
			Title = model.Title,
			Description = model.Description,
			Price = model.Price,
		};
		return _productRegistrationViewModel;
	}
}
