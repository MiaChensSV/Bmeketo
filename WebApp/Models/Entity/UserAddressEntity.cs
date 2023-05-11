using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entity;

[PrimaryKey(nameof(UserId), nameof(AddressId))]

public class UserAddressEntity
{
	[ForeignKey(nameof(User))]
	public string UserId { get; set; } = null!;
    public AppIdentityUser User { get; set; }=null!;

	[ForeignKey(nameof(Address))]
	public int AddressId { get; set; } 
    public AddressEntity Address { get; set; } = null!;
}
