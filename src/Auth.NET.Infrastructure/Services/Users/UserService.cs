using Auth.NET.Infrastructure.Data;
using Auth.NET.Libs.Entities.Users;

namespace Auth.NET.Infrastructure.Services.Users;

public class UserService(AuthDbContext context)
{
    private readonly AuthDbContext _context = context;

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }
}