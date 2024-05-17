using Microsoft.AspNetCore.Identity;
using System.Reflection;

namespace BlazorWebApp_Silicon.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string? ApplicationUserProfileId { get; set; }
        public ApplicationUserProfile? UserProfile { get; set; }
        public string? ApplicationUserAddressId { get; set; }
        public ApplicationUserAddress? UserAddress { get; set; }
    }

}
