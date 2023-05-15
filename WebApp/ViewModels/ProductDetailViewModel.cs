using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entity;
using WebApp.Models;

namespace WebApp.ViewModels;

public class ProductDetailViewModel:ProductModel
{

	public int Rating { get; set; }	
	
}
