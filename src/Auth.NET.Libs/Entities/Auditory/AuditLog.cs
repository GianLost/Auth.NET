using Auth.NET.Libs.Domain.Entities;

namespace Auth.NET.Libs.Entities.Auditory;

/// <summary>
/// Represents an audit log entry, used for tracking user actions and system events.
/// </summary>
public class AuditLog : TAuditLog<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLog"/> class with the specified user ID, action, and IP address.
    /// </summary>
    /// <param name="userId">The ID of the user associated with the action.</param>
    /// <param name="action">The action performed by the user. Cannot be null.</param>
    /// <param name="ipAddress">The IP address of the user. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="action"/> or <paramref name="ipAddress"/> is null.
    /// </exception>
    public AuditLog(Guid userId, string action, string ipAddress)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        Action = action ?? throw new ArgumentNullException(nameof(action));
        Timestamp = DateTime.UtcNow;
        IPAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
    }
}