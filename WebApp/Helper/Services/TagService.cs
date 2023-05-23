using System.Collections;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Helper.Repositories;
using WebApp.Models.Entity;

namespace WebApp.Helper.Services;
public class TagService
{
    private readonly TagRepository _tagRepo;
	private readonly ProductTagRepository _productTagRepo;

	public TagService(TagRepository tagRepo, ProductTagRepository productTagRepo)
	{
		_tagRepo = tagRepo;
		_productTagRepo = productTagRepo;
	}

	public async Task<List<SelectListItem>> GetTagsAsync()
    {
        var _tags=new List<SelectListItem>();    
        foreach(var tag in await _tagRepo.GetAllAsync())
        {
            _tags.Add(new SelectListItem
            {
                Value = tag.Id.ToString(),
                Text = tag.TagName
            });
        }
        return _tags;
    }

	public async Task<List<SelectListItem>> GetTagsAsync(string[] selectedTags)
	{
		var _tags = new List<SelectListItem>();
		foreach (var tag in await _tagRepo.GetAllAsync())
		{
            _tags.Add(new SelectListItem
			{
				Value = tag.Id.ToString(),
				Text = tag.TagName,
                Selected=selectedTags.Contains(tag.Id.ToString())
			});
		}
		return _tags;
	}
    public async Task<List<SelectListItem>> GetProductTagsAsync(string articleNumber)
    {
		List<ProductTagEntity> _tagList = _productTagRepo.GetAllAsync(x => x.ArticleNumber == articleNumber).Result.ToList<ProductTagEntity>();
		List<string> _tagListStr = new List<string>();
        _tagList.ForEach(x => _tagListStr.Add(x.TagId.ToString()));
		var _tags=new List<SelectListItem>();
		foreach(var tag in await _tagRepo.GetAllAsync())
		{
            _tags.Add(new SelectListItem
			{

				Value = tag.Id.ToString(),
				Text = tag.TagName,
				Selected = _tagListStr.Contains(tag.Id.ToString())
			});
		}
		return _tags;
    }
}
