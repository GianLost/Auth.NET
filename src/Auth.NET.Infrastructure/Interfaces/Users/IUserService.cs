using Auth.NET.Libs.Entities.Users;

namespace Auth.NET.Infrastructure.Interfaces.Users;

public interface IUserService
{
    Task<User> CreateUserAsync(User user);
}