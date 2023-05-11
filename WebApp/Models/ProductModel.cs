using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entity;

namespace WebApp.Models;

public class ProductModel
{
	public Guid Id { get; set; } 
	public string ArticleNumber { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public decimal Price { get; set; }
	public string? ImageUrl { get; set; }
	public string? CatagoryId { get; set; }
	public string CategoryName { get; set; } = null!;
	public int TagId { get; set; }
	public string TagName { get; set; } = null!;
}
