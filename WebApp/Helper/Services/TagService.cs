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
    private readonly ProductRepository _productRepo;
	private readonly ProductTagRepository _productTagRepo;

	public TagService(TagRepository tagRepo, ProductRepository productRepo, ProductTagRepository productTagRepo)
	{
		_tagRepo = tagRepo;
		_productRepo = productRepo;
		_productTagRepo = productTagRepo;
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
    public async Task<List<SelectListItem>> GetProductTagsAsync(string articleNumber)
    {
		List<ProductTagEntity> tagList = _productTagRepo.GetAllAsync(x => x.ArticleNumber == articleNumber).Result.ToList<ProductTagEntity>();
		List<string> tagListStr = new List<string>();
		tagList.ForEach(x => tagListStr.Add(x.TagId.ToString()));
		var tags=new List<SelectListItem>();
		foreach(var tag in await _tagRepo.GetAllAsync())
		{
			tags.Add(new SelectListItem
			{

				Value = tag.Id.ToString(),
				Text = tag.TagName,
				Selected = tagListStr.Contains(tag.Id.ToString())
			});
		}
		return tags;
    }
}
