using Microsoft.AspNetCore.Identity;

namespace CourtHouse.Models
{
    public class User:IdentityUser
    {
        public Region region { get; set; }
    }
}
