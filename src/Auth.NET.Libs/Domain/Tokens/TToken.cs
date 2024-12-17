using Auth.NET.Libs.Domain.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.NET.Libs.Domain.Tokens;

/// <summary>
/// Represents a token used for authentication or authorization purposes.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user and token.</typeparam>
public abstract class TToken<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the token.
    /// </summary>
    [Key]
    [Required]
    public virtual TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with this token.
    /// </summary>
    [ForeignKey(nameof(User))]
    public virtual TKey UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this token.
    /// </summary>
    public virtual TUser<TKey> User { get; set; }

    /// <summary>
    /// Gets or sets the value of the token.
    /// </summary>
    [Required]
    public virtual string TokenValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the expiration date and time of the token.
    /// </summary>
    [Required]
    public virtual DateTime Expiration { get; set; }

    /// <summary>
    /// Gets the date and time when the token was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}