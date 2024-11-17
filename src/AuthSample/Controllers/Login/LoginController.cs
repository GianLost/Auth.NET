using Microsoft.AspNetCore.Mvc;

namespace AuthSample.Controllers.Login;
public class LoginController : Controller
{
    public IActionResult SignIn() => View();
}