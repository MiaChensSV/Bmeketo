using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helper;
using WebApp.Helper.Repositories;
using WebApp.Helper.Services;
using WebApp.Models.Identity;
using WebApp.Services;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<SeedService>();
        builder.Services.AddScoped<SeedRoleService>();
        builder.Services.AddScoped<ShowcaseService>();
        builder.Services.AddScoped<AddressService>();
        builder.Services.AddScoped<AuthService>();
        builder.Services.AddScoped<TagService>();
		builder.Services.AddScoped<ProductService>();
		builder.Services.AddScoped<CategoryService>();
		builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<ContactService>();



        builder.Services.AddScoped<AddressRepository>();
		builder.Services.AddScoped<UserAddressRepository>();
        builder.Services.AddScoped<TagRepository>();
		builder.Services.AddScoped<ProductRepository>();
		builder.Services.AddScoped<ProductTagRepository>();
		builder.Services.AddScoped<CategoryRepository>();
		builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<ContactRepository>();





		builder.Services.AddIdentity<AppIdentityUser, IdentityRole>(x =>
        {
            x.SignIn.RequireConfirmedAccount = false;
            x.Password.RequiredLength= 8;
            x.User.RequireUniqueEmail= true;
        })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddClaimsPrincipalFactory<CustomClaimsPricipalFactory>();

        builder.Services.ConfigureApplicationCookie(x =>
        {
            x.LoginPath = "/login";
            x.LogoutPath = "/";
            x.AccessDeniedPath = "/denied";
        });

		builder.Services.AddDbContext<WebContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
        builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));


        var app = builder.Build();

        app.UseHsts();

        //seeds database
		using (var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<WebContext>();
				context.Database.Migrate();
				SeedService.Initialize(services);
			}

			catch (Exception ex)
			{
				var logger = services.GetRequiredService<ILogger<Program>>();
				logger.LogError(ex, "Initialize Database failed.");
			}

		}

		app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

	

	}
}