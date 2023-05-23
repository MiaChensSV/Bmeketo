using Microsoft.AspNetCore.Identity;
using WebApp.Models.Entity;

namespace WebApp.Models.Identity;

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

    public static implicit operator UserModel(AppIdentityUser user)
    {
        var _newUserModel = new UserModel
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            CompanyName = user.CompanyName,
            ProfileImageUrl = user.ProfileImageUrl,
        };
        return _newUserModel;
    }
}
