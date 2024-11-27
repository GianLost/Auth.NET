namespace Auth.NET.Libs.Domain.Entities;

/// <summary>
/// Represents a token used for authentication or authorization purposes.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user and token.</typeparam>
public abstract class TToken<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the token.
    /// </summary>
    public TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with this token.
    /// </summary>
    public TKey UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this token.
    /// </summary>
    public TUser<TKey> User { get; set; }

    /// <summary>
    /// Gets or sets the value of the token.
    /// </summary>
    public string TokenValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the expiration date and time of the token.
    /// </summary>
    public DateTime Expiration { get; set; }

    /// <summary>
    /// Gets the date and time when the token was created.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}