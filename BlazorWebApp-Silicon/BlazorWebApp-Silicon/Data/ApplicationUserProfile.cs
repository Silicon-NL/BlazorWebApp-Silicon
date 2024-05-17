namespace BlazorWebApp_Silicon.Data
{
    public class ApplicationUserProfile
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? ProfilePicture { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Biography { get; set; }
    }

}
