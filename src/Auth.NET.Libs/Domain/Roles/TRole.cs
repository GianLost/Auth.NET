using System.ComponentModel.DataAnnotations;

namespace Auth.NET.Libs.Domain.Roles;

/// <summary>
/// Represents a role entity that defines a set of permissions or responsibilities
/// for users in the system.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the role.</typeparam>
public abstract class TRole<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the role.
    /// </summary>
    [Key]
    [Required]
    public virtual TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    [Required]
    public virtual string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the role.
    /// </summary>
    [Required]
    public virtual string Description { get; set; }

    /// <summary>
    /// Gets or sets the collection of user-role relationships associated with this role.
    /// </summary>
    public virtual ICollection<TUserRole<TKey>> UserRoles { get; set; } = new HashSet<TUserRole<TKey>>();
}