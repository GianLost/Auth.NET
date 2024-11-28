using Auth.NET.Libs.Domain.Users;

namespace Auth.NET.Libs.Entities.Users;

/// <summary>
/// Represents the default implementation of a user entity using a string-based unique identifier.
/// </summary>
public class User : TUser<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class with default values.
    /// </summary>
    public User()
    {
        Initialize();
    }

    /// <summary>
    /// Initializes default property values for the user.
    /// </summary>
    private void Initialize()
    {
        Id = Guid.NewGuid().ToString();
        FailedAttempts = 0;
        IsLockedOut = false;
    }
}