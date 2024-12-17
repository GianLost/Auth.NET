using Auth.NET.Infrastructure.Interfaces.Users;
using Auth.NET.Infrastructure.Services.Users;
using Auth.NET.Libs.Entities.Users;
using Auth.NET.Libs.Helpers.Crypt;
using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Controllers.Users;

public class UserController(UserService userService) : Controller
{

    private readonly UserService _userService = userService;

    public IActionResult Index() => View();
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(User user, string? userEncrypted = null)
    {
        if (user == null || string.IsNullOrEmpty(userEncrypted))
            return BadRequest("User cannot be null");

        user = await JSONDataTransfer<User>.JSONSecureDataDesserialize(userEncrypted);

        await _userService.CreateUserAsync(user);

        return Ok(user);
    }
}