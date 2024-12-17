using Auth.NET.Libs.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.NET.Libs.Domain.Roles;

/// <summary>
/// Represents a relationship between a user and a role in the system.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user and role.</typeparam>
public abstract class TUserRole<TKey> where TKey : IEquatable<TKey>
{
    [Key]
    [Required]
    public virtual TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    [ForeignKey(nameof(User))]
    public virtual TKey UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this user-role relationship.
    /// </summary>
    public virtual TUser<TKey> User { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier for the role.
    /// </summary>
    [ForeignKey(nameof(Role))]
    public virtual TKey RoleId { get; set; }

    /// <summary>
    /// Gets or sets the role associated with this user-role relationship.
    /// </summary>
    public virtual TRole<TKey> Role { get; set; }
}