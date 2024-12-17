using Auth.NET.Libs.Domain.Roles;

namespace Auth.NET.Libs.Entities.Roles;

/// <summary>
/// Represents the relationship between a user and a role.
/// </summary>
public class UserRole : TUserRole<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    public UserRole()
    {
        Id = Guid.NewGuid().ToString();
    }
}