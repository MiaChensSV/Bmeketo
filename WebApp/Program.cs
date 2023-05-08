using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;
using WebApp.Helper.Services;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ShowcaseService>();//new ShowcaseService
            builder.Services.AddDbContext<WebContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Sql")));
            builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentitySql")));

            var app = builder.Build();

            app.UseHsts();
            
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
}