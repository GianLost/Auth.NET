using Auth.NET.Libs.Domain.Tokens;

namespace Auth.NET.Libs.Entities.Tokens;

/// <summary>
/// Represents a token used for authentication or authorization in the system.
/// </summary>
public class Token : TToken<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Token"/> class with the specified value, user ID, and expiration date.
    /// </summary>
    /// <param name="value">The token value. Cannot be null or empty.</param>
    /// <param name="userId">The ID of the user associated with the token.</param>
    /// <param name="expiration">The expiration date and time of the token. Must be in the future.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is null or empty.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="expiration"/> is not in the future.</exception>
    public Token(string value, Guid userId, DateTime expiration)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        TokenValue = !string.IsNullOrWhiteSpace(value)
            ? value
            : throw new ArgumentNullException(nameof(value));
        Expiration = expiration > DateTime.UtcNow
            ? expiration
            : throw new ArgumentOutOfRangeException(nameof(expiration), "Expiration must be in the future.");
        CreatedAt = DateTime.UtcNow;
    }
}