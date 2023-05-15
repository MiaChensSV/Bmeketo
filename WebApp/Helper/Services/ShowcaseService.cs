using WebApp.Models;

namespace WebApp.Helper.Services;

public class ShowcaseService
{
    private ShowcaseModel showcasemodel = new ShowcaseModel
    {
        Ingress = "Welcome to Bmekerto Shop",
        Title = "Exclusive Chair gold Collection.",
        ImageUrl = "/images/Showcases/black-friday.jpg",
        Button = new LinkButtonModel
        {
            LinkText = "ShopNow",
            Url = "URL",
        },
    };
    public ShowcaseModel GetShowcase()
    {
        return showcasemodel;
    }
}
