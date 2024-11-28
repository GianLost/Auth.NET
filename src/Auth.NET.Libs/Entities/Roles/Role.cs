using Auth.NET.Libs.Domain.Roles;

namespace Auth.NET.Libs.Entities.Roles;

/// <summary>
/// Represents a role in the system, defining permissions or responsibilities.
/// </summary>
public class Role : TRole<Guid>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class with the specified name and description.
    /// </summary>
    /// <param name="name">The name of the role. Cannot be null or empty.</param>
    /// <param name="description">The description of the role. Optional.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> is null or empty.</exception>
    public Role(string name, string description = null)
    {
        Id = Guid.NewGuid();
        Name = !string.IsNullOrWhiteSpace(name)
            ? name
            : throw new ArgumentNullException(nameof(name));
        Description = description;
    }
}