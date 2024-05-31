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
    public string? Currency { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public decimal StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public bool IsVisible { get; set; } = true;
    public string? Content { get; set; }
    public string[]? Includes { get; set; }
    public ProgramDetail[]? ProgramDetails { get; set; }

    public string ToQueryString()
    {
        return $"Id={Id}" +
               $"&BestSeller={IsBestSeller}" +
               $"&ImageUri={Uri.EscapeDataString(ImageUri)}" +
               $"&Title={Uri.EscapeDataString(Title)}" +
               $"&Description={Uri.EscapeDataString(Ingress)}" +
               $"&Author={Uri.EscapeDataString(Author)}" +
               $"&Likes={Likes}" +
               $"&LikesInPercent={LikesInProcent}" +
               $"&Price={Price}";
    }
}

public class ProgramDetail
{
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}