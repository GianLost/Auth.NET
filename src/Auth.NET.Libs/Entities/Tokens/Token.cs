using Auth.NET.Libs.Domain.Tokens;
using Auth.NET.Libs.Entities.Users;

namespace Auth.NET.Libs.Entities.Tokens;

/// <summary>
/// Represents a token used for authentication or authorization.
/// </summary>
public class Token : TToken<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Token"/> class.
    /// </summary>
    public Token()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTime.UtcNow;
    }
}