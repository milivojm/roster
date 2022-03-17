namespace Roster.Core;

public class MembershipApplication
{
    readonly string _hashedPassword;

    public MembershipApplication(string firstName, string lastName, string username, string email, string hashedPassword)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        _hashedPassword = hashedPassword;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; private set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? Age { get; set; }
}