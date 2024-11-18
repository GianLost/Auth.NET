using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Controllers.Users;

public class UserController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Register() => View();
}
