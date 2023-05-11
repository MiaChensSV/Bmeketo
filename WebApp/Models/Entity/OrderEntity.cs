using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entity;
[PrimaryKey(nameof(OrderId))]

public class OrderEntity
{
	public OrderEntity()
	{
		OrderId = Guid.NewGuid();
		OrderDate= DateTime.Now;
		OrderRows = new HashSet<OrderRowEntity>();
	}
	public Guid OrderId { get; set; }
	public DateTime OrderDate { get; set; } 

	[Column(TypeName ="money")]
	public decimal TotalAmount { get; set; }
	public Guid UserId { get; set; }
	public ICollection<OrderRowEntity> OrderRows { get; set;}
}
