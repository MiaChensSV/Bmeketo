using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class ContactRepository : Repository<ContactFormEntity>
{
    public ContactRepository(WebContext webContext) : base(webContext)
    {
    }
}
