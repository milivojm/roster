namespace Roster.Core;

public class MembershipApplication
{
    string? _hashedPassword;
    bool _accepted;

    public static MembershipApplication Submit(
        string firstName,
        string lastName,
        string username,
        string plainTextPassword,
        string email,
        string? phoneNumber,
        int? age)
    {
        MembershipApplication app = new(firstName, lastName, username, email);
        app.Age = age;
        app.PhoneNumber = phoneNumber;

        PasswordHasher passwordHasher = new();
        string hashedPassword = passwordHasher.HashPassword(plainTextPassword);
        app.StorePassword(hashedPassword);

        return app;
    }

    public MembershipApplication(string firstName, string lastName, string username, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; private set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public int? Age { get; set; }
    public bool Accepted => _accepted;

    public void StorePassword(string hashedPassword)
    {
        _hashedPassword = hashedPassword;
    }

    public void Accept()
    {
        _accepted = true;
    }
}
