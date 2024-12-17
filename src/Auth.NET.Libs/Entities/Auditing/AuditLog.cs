using Auth.NET.Libs.Domain.Auditing;
using Auth.NET.Libs.Entities.Users;

namespace Auth.NET.Libs.Entities.Auditing;

/// <summary>
/// Represents an audit log entry for tracking user actions.
/// </summary>
public class AuditLog : TAuditLog<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuditLog"/> class.
    /// </summary>
    public AuditLog()
    {
        Id = Guid.NewGuid().ToString();
        Timestamp = DateTime.UtcNow;
    }
}