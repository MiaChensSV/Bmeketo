﻿using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helper.Repositories;
using WebApp.Models.Entity;

namespace WebApp.Helper.Services;

public class SeedService
{
	//private readonly WebContext _context;
	//private readonly CategoryRepository _categoryRepo;
	//private readonly TagRepository _tagRepo;


	//public SeedService(WebContext context, CategoryRepository categoryRepo, TagRepository tagRepo)
	//{
	//	_context = context;
	//	_categoryRepo = categoryRepo;
	//	_tagRepo = tagRepo;
	//}

	public static async void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new WebContext(serviceProvider.GetRequiredService<DbContextOptions<WebContext>>()))
		{
			if (context.Categories.Any())
			{
				return; 
			}
			context.Categories.AddRange(
				new CategoryEntity { CategoryName = "Bag" },
				new CategoryEntity { CategoryName = "Dress" },
				new CategoryEntity { CategoryName = "Decoration" },
				new CategoryEntity { CategoryName = "Essentials" },
				new CategoryEntity { CategoryName = "Interior" },
				new CategoryEntity { CategoryName = "Laptop" },
				new CategoryEntity { CategoryName = "Mobile" },
				new CategoryEntity { CategoryName = "Beauty" });
			await context.SaveChangesAsync();
			if (context.Tags.Any())
			{
				return;
			}
			context.Tags.AddRange(
				new TagEntity { TagName = "New" },
				new TagEntity { TagName = "Popular" },
				new TagEntity { TagName = "Onsale" },
				new TagEntity { TagName = "Club Price" });
			await context.SaveChangesAsync();

			if (context.Products.Any())
			{
				return;
			}
			context.Products.AddRange(
				new ProductEntity
				{
					ArticleNumber = "1024534",
					Title = "120 Hz 15,6 gaminglaptop med AMD Ryzen™ 5 & GTX 1650",
					Description = "Med Lenovo Gaming 3 får du en gaminglaptop som även passar bra för dig som håller på med kreativt skapande. Den snabba AMD Ryzen™ 5-processorn skapar snabba flöden och program som laddar på nolltid. Du får även tillgång till 8 GB DDR4-minne, en SSD-hårddisk på 512 GB och grafikkortet NVIDIA GeForce GTX 1650. Spela dina favoritspel, streama film eller redigera i Photoshop. Den 15,6\" stora skärmen visar ditt innehåll i Full HD-upplösning med fin kontrast och bra skärpa i detaljerna. Upplev nya funktioner och förbättrad säkerhet i Windows 11 Home.",
					Price = 8990,
					ImageUrl = "/images/products/lenovo-gaming-3-15ach6-82k201h2mx(1024534)_501498_1_Normal_Extra.webp",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Laptop")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "1025863",
					Title = "Prisvärd Xiaomi Redmi 10 med Quad-kamera",
					Description = "Letar du efter en prisvärd telefon med kraftfullt batteri, snabb och responsiv skärm och en kamera som låter dig släppa fram din inre kreatör? Då är Xiaomi Redmi 10 något för dig. Med ett quad-kamerasystem fullskpäckat med filter och funktioner är det lätt att skapa och bevara dina minnen, och den snabba skärmen gör dina alster rättvisa. Telefonen är försedd med en kraftfull processor och ett batteri som håller länge, allt i en snygg och nätt design. ",
					Price = 1990,
					ImageUrl = "/images/products/xiaomi-redmi-10-2022-4128gb-carbon-gray(1025863)_517797_2_Normal_Large.webp",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Mobile")).Id,

				},
				new ProductEntity
				{
					ArticleNumber = "1024L39",
					Title = "RO-NORATWO HIGH L39",
					Description = "Stomme av metall/formgjuten kallskum.\r\nBen i betsad ask.\r\nFinish: Enligt standardkulörer.\r\nFilt- eller PVC-glidfot.",
					Price = 3990,
					ImageUrl = "/images/products/image_1_1673435971668.jfif",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Interior")).Id,

				},
				new ProductEntity
				{
					ArticleNumber = "65725678",
					Title = "Invisible Illumination Liquid Blush",
					Description = "Invisible Illumination Liquid Blush är ett flytande rouge som återfuktar och ger huden en naturlig färg  med strålande finish. Den lätta, veganska formulan innehåller återfuktande nordiska alger, lystergivande nordisk mjölkört och lugnande E-vitamin som omedelbart gör huden jämnare och mer strålande. Kan appliceras i flera lager för en mer intensiv nyans.\r\nVegansk\r\nVolym 15ml.",
					Price = 319,
					ImageUrl = "/images/products/6412600847536_front.webp",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Beauty")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "65467959",
					Title = "Msn Bag",
					Description = "MSN Bag omtolkar den klassiska skolryggsäcken för moderna stadsklara garderober. Fokuspunkterna för denna annars minimalistiska siluett kommer som dubbla remmar och karakteristiska signaturkarbinhakar. Denna vattentäta ryggsäck rymmer en intern ficka för laptop och ett rymligt huvudfack. Designen är avslutad med justerbara ryggband.\r\n\r\nMSN Bag är skuren i Rains signatur vattentäta PU-tyg, konstruerad för att bära styrka, hållbarhet och en mjuk känsla.\r\n",
					Price = 899,
					ImageUrl = "/images/products/20AP6DPYGI_65467959_front.webp",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Bags")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "65760609",
					Title = "Sc-Le 2 Dress",
					Description = "SC-Le 2 är en färgglad klänning i ekologisk bomull. Den här klänningen har en fin lös passform, skjortkrage, korta ärmar,  vid kjol och ett fint tryck. Styla den här coola klänningen med ett par snygga stövlar för en edgy look.\r\nEkologisk bomull, vilket innebär att den här produktens råvaror eller ingredienser har odlats utan kemiska bekämpningsmedel och konstgödsel.",
					Price = 599,
					ImageUrl = "/images/products/83APNKBBVE_65760609_front.jpg",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Dress")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "44713055",
					Title = "Äng Small Brass",
					Description = "Äng ger oss möjligheten att arrangera blommor på ett nytt sätt. Tanken är att varje blomma behöver två stödpunkter för att stå. Med sin enkla men finurliga konstruktion möjliggörs att arrangera blommor i olika höjder och mängder. Vasen är tillverkad i m",
					Price = 900,
					ImageUrl = "/images/products/52AP9W38LF_44713055_n_front.webp",
					//CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Decoration")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "89926168",
					Title = "Linnevatten Presentbox: Längtan, Harmoni, Välbehag & Sport 4x100 ml, 100ML X4ST",
					Description = "Presentbox från Washologi. Innehåller 4x100 ml linnevatten med olika användningsområden:\r\n\r\nLÄNGTAN ger en naturlig mjuk doft av bomullsblomma.\r\nHARMONI med en lugnande doft av lavendel.\r\nVÄLBEHAG ger dig en rofylld doft av mimosa.\r\nSPORT med en berusande doft av jasmin.",
					Price = 319,
					ImageUrl = "/images/products/61APZHX8JM_7350078660181_Front.jpg",
				//	CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Essentials")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "90979266",
					Title = "Loungefåtölj ALMA 72 cm",
					Description = "En fåtölj som passar perfekt till loungen. \r\n\r\n• Sitthöjd: 41 cm.\r\n• Höjd: 72 cm\r\n• Bredd: 64 cm",
					Price = 2199,
					ImageUrl = "/images/products/11API7DCSN_90979266_Ahlens_Front.webp",
				//	CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Interior")).Id,
				},
				new ProductEntity
				{
					ArticleNumber = "79573879",
					Title = "La Vie Est Belle Eau de Parfum",
					Description = "Lancôme La Vie est Belle Eau de Parfum är Lancômes ikoniska, eleganta och moderna doft för kvinnor. Doftens toppnot består av iris, hjärtnoten av patchouli och basen av söta gourmandnoter.",
					Price = 1070,
					ImageUrl = "/images/products/72APMG3OST_79573879_bigswatch.webp",
				//	CategoryId = (await categoryRepo.GetAsync(x => x.CategoryName == "Beauty")).Id,
				});
				await context.SaveChangesAsync();
		}
	}

	
	//private async Task InitializeAsync()
	//{ 
	//	await InitializeCategoriesAsync();
	//	await InitializeTagsAsync();
	//	await InitializeProductsAsync();
	//}

	//private async Task InitializeCategoriesAsync()
	//{
	//	if (await _context.Categories.AnyAsync())
	//	{
	//		var _categories = new List<CategoryEntity>
	//		{
	//			new CategoryEntity{CategoryName="Bag"},
	//			new CategoryEntity{CategoryName="Dress"},
	//			new CategoryEntity{CategoryName="Decoration"},
	//			new CategoryEntity{CategoryName="Essentials"},
	//			new CategoryEntity{CategoryName="Interior"},
	//			new CategoryEntity{CategoryName="Laptop"},
	//			new CategoryEntity{CategoryName="Mobile"},
	//			new CategoryEntity{CategoryName="Beauty"},
	//		};
	//		await _context.Categories.AddRangeAsync(_categories);
	//		await _context.SaveChangesAsync();
	//	}

	//}

	//private async Task InitializeTagsAsync()
	//{
	//	if (await _context.Tags.AnyAsync())
	//	{
	//		var _tags = new List<TagEntity>
	//		{
	//			new TagEntity{TagName="New"},
	//			new TagEntity{TagName="Popular"},
	//			new TagEntity{TagName="Onsale"},
	//			new TagEntity{TagName="Club Price"},

	//		};
	//		await _context.Tags.AddRangeAsync(_tags);
	//		await _context.SaveChangesAsync();
	//	}
	//}

	//private async Task InitializeProductsAsync()
	//{
	//	if (await _context.Products.AnyAsync())
	//	{
	//		var _products = new List<ProductEntity>
	//		{
	//			new ProductEntity
	//			{
	//				ArticleNumber = "1024534",
	//				Title = "120 Hz 15,6 gaminglaptop med AMD Ryzen™ 5 & GTX 1650",
	//				Description = "Med Lenovo Gaming 3 får du en gaminglaptop som även passar bra för dig som håller på med kreativt skapande. Den snabba AMD Ryzen™ 5-processorn skapar snabba flöden och program som laddar på nolltid. Du får även tillgång till 8 GB DDR4-minne, en SSD-hårddisk på 512 GB och grafikkortet NVIDIA GeForce GTX 1650. Spela dina favoritspel, streama film eller redigera i Photoshop. Den 15,6\" stora skärmen visar ditt innehåll i Full HD-upplösning med fin kontrast och bra skärpa i detaljerna. Upplev nya funktioner och förbättrad säkerhet i Windows 11 Home.",
	//				Price = 8990,
	//				ImageUrl="/images/products/lenovo-gaming-3-15ach6-82k201h2mx(1024534)_501498_1_Normal_Extra.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Laptop")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "1025863",
	//				Title = "Prisvärd Xiaomi Redmi 10 med Quad-kamera",
	//				Description = "Letar du efter en prisvärd telefon med kraftfullt batteri, snabb och responsiv skärm och en kamera som låter dig släppa fram din inre kreatör? Då är Xiaomi Redmi 10 något för dig. Med ett quad-kamerasystem fullskpäckat med filter och funktioner är det lätt att skapa och bevara dina minnen, och den snabba skärmen gör dina alster rättvisa. Telefonen är försedd med en kraftfull processor och ett batteri som håller länge, allt i en snygg och nätt design. ",
	//				Price = 1990,
	//				ImageUrl="/images/products/xiaomi-redmi-10-2022-4128gb-carbon-gray(1025863)_517797_2_Normal_Large.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Mobile")).Id,

	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "1024L39",
	//				Title = "RO-NORATWO HIGH L39",
	//				Description = "Stomme av metall/formgjuten kallskum.\r\nBen i betsad ask.\r\nFinish: Enligt standardkulörer.\r\nFilt- eller PVC-glidfot.",
	//				Price = 3990,
	//				ImageUrl="/images/products/image_1_1673435971668.jfif",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Interior")).Id,

	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "65725678",
	//				Title = "Invisible Illumination Liquid Blush",
	//				Description = "Invisible Illumination Liquid Blush är ett flytande rouge som återfuktar och ger huden en naturlig färg  med strålande finish. Den lätta, veganska formulan innehåller återfuktande nordiska alger, lystergivande nordisk mjölkört och lugnande E-vitamin som omedelbart gör huden jämnare och mer strålande. Kan appliceras i flera lager för en mer intensiv nyans.\r\nVegansk\r\nVolym 15ml.",
	//				Price = 319,
	//				ImageUrl="/images/products/6412600847536_front.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Beauty")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "65467959",
	//				Title = "Msn Bag",
	//				Description = "MSN Bag omtolkar den klassiska skolryggsäcken för moderna stadsklara garderober. Fokuspunkterna för denna annars minimalistiska siluett kommer som dubbla remmar och karakteristiska signaturkarbinhakar. Denna vattentäta ryggsäck rymmer en intern ficka för laptop och ett rymligt huvudfack. Designen är avslutad med justerbara ryggband.\r\n\r\nMSN Bag är skuren i Rains signatur vattentäta PU-tyg, konstruerad för att bära styrka, hållbarhet och en mjuk känsla.\r\n",
	//				Price = 899,
	//				ImageUrl="/images/products/20AP6DPYGI_65467959_front.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Bags")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "65760609",
	//				Title = "Sc-Le 2 Dress",
	//				Description = "SC-Le 2 är en färgglad klänning i ekologisk bomull. Den här klänningen har en fin lös passform, skjortkrage, korta ärmar,  vid kjol och ett fint tryck. Styla den här coola klänningen med ett par snygga stövlar för en edgy look.\r\nEkologisk bomull, vilket innebär att den här produktens råvaror eller ingredienser har odlats utan kemiska bekämpningsmedel och konstgödsel.",
	//				Price = 599,
	//				ImageUrl="/images/products/83APNKBBVE_65760609_front.jpg",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Dress")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "44713055",
	//				Title = "Äng Small Brass",
	//				Description = "Äng ger oss möjligheten att arrangera blommor på ett nytt sätt. Tanken är att varje blomma behöver två stödpunkter för att stå. Med sin enkla men finurliga konstruktion möjliggörs att arrangera blommor i olika höjder och mängder. Vasen är tillverkad i m",
	//				Price = 900,
	//				ImageUrl="/images/products/52AP9W38LF_44713055_n_front.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Decoration")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "89926168",
	//				Title = "Linnevatten Presentbox: Längtan, Harmoni, Välbehag & Sport 4x100 ml, 100ML X4ST",
	//				Description = "Presentbox från Washologi. Innehåller 4x100 ml linnevatten med olika användningsområden:\r\n\r\nLÄNGTAN ger en naturlig mjuk doft av bomullsblomma.\r\nHARMONI med en lugnande doft av lavendel.\r\nVÄLBEHAG ger dig en rofylld doft av mimosa.\r\nSPORT med en berusande doft av jasmin.",
	//				Price = 319,
	//				ImageUrl="/images/products/61APZHX8JM_7350078660181_Front.jpg",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Essentials")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "90979266",
	//				Title = "Loungefåtölj ALMA 72 cm",
	//				Description = "En fåtölj som passar perfekt till loungen. \r\n\r\n• Sitthöjd: 41 cm.\r\n• Höjd: 72 cm\r\n• Bredd: 64 cm",
	//				Price = 2199,
	//				ImageUrl="/images/products/11API7DCSN_90979266_Ahlens_Front.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Interior")).Id,
	//			},
	//			new ProductEntity
	//			{
	//				ArticleNumber = "79573879",
	//				Title = "La Vie Est Belle Eau de Parfum",
	//				Description = "Lancôme La Vie est Belle Eau de Parfum är Lancômes ikoniska, eleganta och moderna doft för kvinnor. Doftens toppnot består av iris, hjärtnoten av patchouli och basen av söta gourmandnoter.",
	//				Price = 1070,
	//				ImageUrl="/images/products/72APMG3OST_79573879_bigswatch.webp",
	//				CategoryId=(await _categoryRepo.GetAsync(x=>x.CategoryName=="Beauty")).Id,
	//			},
	//		};
	//		await _context.Products.AddRangeAsync(_products);
	//		await _context.SaveChangesAsync();
	//	}
	//}



}