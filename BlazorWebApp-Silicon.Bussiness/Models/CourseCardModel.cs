namespace BlazorWebApp_Silicon.Bussiness.Models;

public class CourseCardModel
{
    public string? Id { get; set; }
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string? Author { get; set; }
    public string? Price { get; set; }
    public string? DiscountPrice { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public bool IsVisible { get; set; } = true;
}
