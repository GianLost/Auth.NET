using Auth.NET.Libs.Domain.Auditing;
using Auth.NET.Libs.Domain.Roles;
using Auth.NET.Libs.Domain.Tokens;
using System.ComponentModel.DataAnnotations;

namespace Auth.NET.Libs.Domain.Users;

/// <summary>
/// Represents a generic user entity with essential properties such as ID, name, 
/// login credentials, contact information, account status, and related entities.
/// This class serves as a base for creating user models with specific requirements.
/// </summary>
/// <typeparam name="TKey">
/// The type of the unique identifier for the user, which must implement <see cref="IEquatable{TKey}"/>.
/// </typeparam>
public abstract class TUser<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    [Key]
    [Required]
    public virtual TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the user's full name.
    /// </summary>
    [Required, StringLength(100, MinimumLength = 5)]
    public virtual string Name { get; set; }

    /// <summary>
    /// Gets or sets the user's login name.
    /// </summary>
    [Required, StringLength(50, MinimumLength = 5)]
    public virtual string Login { get; set; }

    /// <summary>
    /// Gets or sets the user's email address.
    /// </summary>
    [Required, EmailAddress]
    public virtual string Email { get; set; }

    /// <summary>
    /// Gets or sets the user's cell phone number.
    /// </summary>
    [Required, Phone]
    public virtual string CellPhone { get; set; }

    /// <summary>
    /// Gets or sets the hashed password for the user.
    /// </summary>
    [Required]
    public virtual string PasswordHash { get; set; }

    /// <summary>
    /// Gets the date and time the user was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time the user was last modified.
    /// </summary>
    public virtual DateTime? ModifyDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time the user last logged in.
    /// </summary>
    public virtual DateTime? LastLogin { get; set; }

    /// <summary>
    /// Gets or sets the number of failed login attempts.
    /// </summary>
    public virtual int FailedAttempts { get; set; }

    /// <summary>
    /// Gets or sets whether the user is locked out of their account.
    /// </summary>
    public virtual bool IsLockedOut { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the user's lockout period.
    /// </summary>
    public virtual DateTime? LockoutEnd { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the last failed login attempt.
    /// </summary>
    public virtual DateTime? LastFailedAttempt { get; set; }

    /// <summary>
    /// Gets or sets the collection of user roles associated with the user.
    /// </summary>
    public virtual ICollection<TUserRole<TKey>> UserRoles { get; set; } = new HashSet<TUserRole<TKey>>();

    /// <summary>
    /// Gets or sets the collection of tokens issued to the user.
    /// </summary>
    public virtual ICollection<TToken<TKey>> Tokens { get; set; } = new HashSet<TToken<TKey>>();

    /// <summary>
    /// Gets or sets the collection of audit logs related to the user.
    /// </summary>
    public virtual ICollection<TAuditLog<TKey>> AuditLogs { get; set; } = new HashSet<TAuditLog<TKey>>();
}