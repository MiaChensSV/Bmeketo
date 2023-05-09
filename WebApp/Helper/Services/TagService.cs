using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Helper.Repositories;

namespace WebApp.Helper.Services;

public class TagService
{
    private readonly TagRepository _tagRepo;

    public TagService(TagRepository tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var tags=new List<SelectListItem>();    
        foreach(var tag in await _tagRepo.GetAllAsync())
        {
            tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName
            });
        }
        return tags;
    }

	public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
	{
		var tags = new List<SelectListItem>();
		foreach (var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName,
                Selected=selectedTags.Contains(tag.Id.ToString())
			});
		}
		return tags;
	}
}
