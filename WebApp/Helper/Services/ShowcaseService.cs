using WebApp.Models;

namespace WebApp.Helper.Services;

public class ShowcaseService
{
    private ShowcaseModel showcasemodel = new ShowcaseModel
    {
        Ingress = "Welcome",
        Title = "Exclusive",
        ImageUrl = "/images/placeholders/625x647.svg",
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
