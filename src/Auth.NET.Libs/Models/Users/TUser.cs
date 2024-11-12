using Auth.NET.Libs.Domain;

namespace Auth.NET.Libs.Models.Users;
public class TUser : TUser<string>
{
    public TUser()
    {
        Initialize();
    }

    private void Initialize()
    {
        Id = Guid.NewGuid().ToString();
        FailedAttempts = 0;
        IsLockedOut = false;
    }
    public override void UpdatePassword(string newPassword)
    {
        throw new NotImplementedException();
    }

    public override bool VerifyPassword(string password)
    {
        throw new NotImplementedException();
    }
}