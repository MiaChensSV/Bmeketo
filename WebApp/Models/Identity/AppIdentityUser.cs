using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entity;

namespace WebApp.Models.Identity
{
    public class AppIdentityUser:IdentityUser
    {
        [ProtectedPersonalData]
        public string FirstName { get; set; } = null!;

        [ProtectedPersonalData]
        public string LastName { get; set; } = null!;

        [ProtectedPersonalData]
        public string? CompanyName { get; set; }

        [ProtectedPersonalData]
        public string? ProfileImageUrl { get; set; }
        public ICollection <UserAddressEntity> Addresses { get; set; }=new HashSet<UserAddressEntity>();
    }
}
