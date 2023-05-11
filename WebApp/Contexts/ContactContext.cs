using Microsoft.EntityFrameworkCore;

namespace WebApp.Contexts
{
	public class ContactContext : DbContext
	{
		public ContactContext(DbContextOptions<ContactContext> options) : base(options)
		{
		}
	}
}
