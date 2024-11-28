using Auth.NET.Libs.Domain.Users;

namespace Auth.NET.Libs.Domain.Auditing;

/// <summary>
/// Represents an audit log entry for tracking user actions and related metadata.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier for the user and log entry.</typeparam>
public abstract class TAuditLog<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets or sets the unique identifier for the audit log entry.
    /// </summary>
    public TKey Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user associated with this log entry.
    /// </summary>
    public TKey UserId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this audit log entry.
    /// </summary>
    public TUser<TKey> User { get; set; }

    /// <summary>
    /// Gets or sets the action performed by the user.
    /// </summary>
    public string Action { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the action occurred.
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the IP address from which the action originated.
    /// </summary>
    public string IPAddress { get; set; }
}