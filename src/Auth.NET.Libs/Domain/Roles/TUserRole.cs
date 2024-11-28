using Auth.NET.Libs.Domain.Users;

namespace Auth.NET.Libs.Domain.Roles;

/// <summary>
/// Represents a relationship between a user and a role in the system.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user and role.</typeparam>
public abstract class TUserRole<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    public TKey UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this user-role relationship.
    /// </summary>
    public TUser<TKey> User { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the role.
    /// </summary>
    public TKey RoleId { get; set; }

    /// <summary>
    /// Gets or sets the role associated with this user-role relationship.
    /// </summary>
    public TRole<TKey> Role { get; set; }
}