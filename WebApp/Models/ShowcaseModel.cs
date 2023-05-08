namespace WebApp.Models;

public class ShowcaseModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public string? ImageUrl { get; set; }
    public LinkButtonModel? Button { get; set; }
}
