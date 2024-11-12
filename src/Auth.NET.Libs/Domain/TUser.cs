using System.ComponentModel.DataAnnotations;

namespace Auth.NET.Libs.Domain;

/// <summary>
/// Abstract base class representing a generic user entity with essential fields
/// such as ID, name, login credentials, contact information, and account status.
/// This class can be extended to create user entities with additional specific requirements.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user, which must implement <see cref="IEquatable{TKey}"/>.</typeparam>
public abstract class TUser<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the user.
    /// </summary>
    [Key]
    public virtual TKey? Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the user. Must be between 5 and 100 characters.
    /// </summary>
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public virtual string? Name { get; set; }

    /// <summary>
    /// Gets or sets the login username for the user. Must be between 5 and 50 characters.
    /// </summary>
    [Required]
    [StringLength(50, MinimumLength = 5)]
    public virtual string? Login { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user. Must be a valid email format.
    /// </summary>
    [Required]
    [EmailAddress]
    public virtual string? Email { get; set; }

    /// <summary>
    /// Gets or sets the cell phone number of the user. Must be a valid phone number format.
    /// </summary>
    [Required]
    [Phone]
    public virtual string? CellPhone { get; set; }

    /// <summary>
    /// Gets or sets the hashed password of the user. This is required for authentication purposes.
    /// </summary>
    [Required]
    public virtual string? PasswordHash { get; set; }

    /// <summary>
    /// Gets the date and time when the user account was created. Default is the current UTC time.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the user information was last modified.
    /// </summary>
    public virtual DateTime? ModifyDate { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the user last logged in.
    /// </summary>
    public virtual DateTime? LastLogin { get; set; }

    /// <summary>
    /// Gets or sets the count of failed login attempts for the user.
    /// </summary>
    public virtual int FailedAttempts { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user account is locked out.
    /// </summary>
    public virtual bool IsLockedOut { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the account lockout period.
    /// </summary>
    public virtual DateTime? LockoutEnd { get; set; }

    /// <summary>
    /// Gets or sets the date and time of the last failed login attempt.
    /// </summary>
    public virtual DateTime? LastFailedAttempt { get; set; }

    /// <summary>
    /// Gets or sets the role of the user, which determines the user's access level or permissions.
    /// </summary>
    public virtual string? Role { get; set; }

    /// <summary>
    /// Verifies if the provided password matches the user's stored password hash.
    /// </summary>
    /// <param name="password">The plain text password to verify.</param>
    /// <returns><c>true</c> if the password matches the hash; otherwise, <c>false</c>.</returns>
    public abstract bool VerifyPassword(string password);

    /// <summary>
    /// Updates the user's password with a new hash based on the provided plain text password.
    /// </summary>
    /// <param name="newPassword">The new plain text password to hash and store.</param>
    public abstract void UpdatePassword(string newPassword);
}