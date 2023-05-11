using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WebApp.Models.Identity;

namespace WebApp.Models.Entity;
[PrimaryKey(nameof(InvoiceId))]
public class InvoiceEntity
{
	public InvoiceEntity()
	{
		InvoiceDate= DateTime.Now;
		DueDate= DateTime.Now.AddDays(30);
		CustomerFullName = null!;
	}
	public Guid InvoiceId { get; set; }
	public DateTime InvoiceDate { get; set; }
	public DateTime DueDate { get; set; }

	[Column(TypeName ="money")]
	public decimal TotalAmount { get; set; }

	[Column(TypeName = "money")]
	public decimal TotalTaxAmount { get; set; }
	public string CustomerFullName { get; set; }
	public string? CustomerFullAddress { get; set; }
	public Guid UserId { get; set; }
	public Guid OrderId { get; set; }

}
