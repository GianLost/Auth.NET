using Auth.NET.Libs.Domain.Roles;

namespace Auth.NET.Libs.Entities.Roles;

/// <summary>
/// Represents a role in the system, defining permissions or responsibilities.
/// </summary>
public class Role : TRole<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class with default values.
    /// </summary>
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}