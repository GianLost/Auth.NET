namespace Auth.NET.Libs.Helpers.Expressions;

/// <summary>
/// Class defining constants for regular expressions and formats used throughout the system.
/// </summary>
public class ConstExpressions
{
    /// <summary>
    /// Regular expression to validate passwords. The password must contain at least 8 characters, 
    /// with at least one uppercase letter, one lowercase letter, one number, and one special character.
    /// </summary>
    public const string StrongPasswordRegex = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{8,30}$";

    /// <summary>
    /// Regular expression to validate phone numbers in the format (XX) XXXXX-XXXX.
    /// </summary>
    public const string PhoneNumberRegex = @"^\(?(?:[0-9]{2})\)?[-. ]?(?:[2-9]|9[1-9])[0-9]{3}[-. ]?[0-9]{4}$";

    /// <summary>
    /// Regular expression to validate email addresses according to RFC 5322 standard.
    /// </summary>
    public const string EmailRegex = @"^(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])"")@(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-zA-Z0-9-]*[a-zA-Z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)])$";

    /// <summary>
    /// Date and time format used for display in the format year-month-day hour:minute:second.
    /// </summary>
    public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
}