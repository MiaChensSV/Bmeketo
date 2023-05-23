using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entity;
[PrimaryKey(nameof(InvoiceRowId),nameof(ProductId))]

public class InvoiceRowEntity
{
	[ForeignKey(nameof(Invoice))]
	public Guid InvoiceRowId { get; set; }
	public InvoiceEntity Invoice { get; set; } = null!;
	public Guid ProductId { get; set; } 

	[Column(TypeName ="money")]
	public decimal ItemPrice { get; set; }

	public int Quantity { get; set; }
		
}
