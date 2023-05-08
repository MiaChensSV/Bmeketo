using WebApp.Contexts;
using WebApp.Models.Entity;

namespace WebApp.Helper.Repositories;

public class TagRepository : Repository<TagEntity>
{
    public TagRepository(WebContext webContext) : base(webContext)
    {
    }
}
