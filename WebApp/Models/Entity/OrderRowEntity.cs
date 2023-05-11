using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entity;
[PrimaryKey(nameof(OrderRowId),nameof(ProductId))]

public class OrderRowEntity
{
	[ForeignKey(nameof(Order))]
	public Guid OrderRowId { get; set; }
	public OrderEntity Order { get; set; } = null!;	
	public Guid ProductId { get; set; }

	[Column(TypeName = "money")]
	public decimal Price { get; set; }
	public int Quantity { get; set; }
}
